using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace Vectrasm
{
    public class AsmVisitor : AsmBaseVisitor<object>
    {
        private Dictionary<string, int> m_equValues = new Dictionary<string, int>();

        private List<ArgumentDeferred> m_deferredArguments = new List<ArgumentDeferred>();

        public List<byte> m_objectCode = new List<byte>();

        private int evaluateExpression(AsmParser.ExprContext context)
        {
            ExpressionVisitor eval = new ExpressionVisitor(m_equValues);
            return eval.Visit(context);
        }

        public override object VisitProg(AsmParser.ProgContext context)
        {
            var result = base.VisitProg(context);
            resolveDeferredArguments();
            return result;
        }

        #region Statements

        public override object VisitStmtEqu(AsmParser.StmtEquContext context)
        {
            string key = context.name.Text;
            int val = evaluateExpression(context.value);

            // TODO: check for duplicates
            m_equValues[key] = val;

            return null;
        }

        public override object VisitStmtData(AsmParser.StmtDataContext context)
        {
            DataListVisitor eval = new DataListVisitor(m_equValues);
            IParseTree data = context.db;
            if (data == null) data = context.dw;
            m_objectCode.AddRange(eval.Visit(data));
            return null;
        }

        public override object VisitStmtLabel(AsmParser.StmtLabelContext context)
        {
            string key = context.IDENTIFIER().GetText();
            int val = m_objectCode.Count;

            // TODO: check for duplicates
            m_equValues[key] = val;
            Console.WriteLine("Label: {0} = {1:X2}/{1}", key, val);

            return null;
        }

        public override object VisitStmtOpcode(AsmParser.StmtOpcodeContext context)
        {
            string opcode = context.opcode.Text.ToUpper();
            Argument argument = null;

            if (context.argument() != null)
            {
                ArgumentVisitor argumentVisitor = new ArgumentVisitor(m_equValues, allowDefer: true);
                argument = argumentVisitor.Visit(context.argument());
            }
            else
            {
                argument = new ArgumentInherent();
            }

            switch (opcode)
            {
                case "ORG":
                    // TODO
                    break;

                case "END":
                    Console.WriteLine("END, program start at {0}", argument);
                    break;

                default:
                    List<Opcode> candidates = Opcode.lookUpOpcode(opcode);
                    if (candidates.Count == 0)
                    {
                        throw new InvalidOperationException("Unsupported opcode '" + opcode + "'");
                    }

                    Console.WriteLine("{0} {1}", opcode, argument);
                    foreach (Opcode candidate in candidates)
                    {
                        Console.WriteLine("  {0}", candidate);
                    }

                    generateInstruction(candidates, argument);

                    break;
            }

            return null;
        }

        #endregion

        private Opcode chooseOpcode(List<Opcode> candidates, Argument argument)
        {
            Opcode matchingOpcode = candidates.SingleOrDefault(o => o.m_addressingMode == argument.m_mode);
            if (matchingOpcode != null)
            {
                return matchingOpcode;
            }
            else if (argument.m_mode == AddressingMode.Extended)
            {
                foreach (Opcode candidate in candidates)
                {
                    if (candidate.m_addressingMode == AddressingMode.Relative)
                    {
                        return candidate;
                    }
                }
            }

            throw new InvalidOperationException("No matching opcode found");
        }

        private void generateInstruction(List<Opcode> candidates, Argument argument)
        {
            Opcode opcode = chooseOpcode(candidates, argument);

            int currentLocation = m_objectCode.Count;
            int nextLocation = currentLocation + 1 + opcode.m_numOperands;

            switch (opcode.m_page)
            {
                case 1: break; // do nothing
                case 2: m_objectCode.Add(16); nextLocation++; break;
                case 3: m_objectCode.Add(17); nextLocation++; break;
                default: throw new InvalidOperationException("Invalid page number");
            }

            m_objectCode.Add(opcode.m_opcode);

            int argumentLocation = m_objectCode.Count;
            m_objectCode.AddRange(argument.generateBytes(opcode, nextLocation));

            Debug.Assert(m_objectCode.Count == nextLocation);

            Console.Write("Generated:");
            for (int i = currentLocation; i < m_objectCode.Count; i++)
                Console.Write(" {0:X2}", m_objectCode[i]);
            Console.WriteLine();

            ArgumentDeferred deferred = argument as ArgumentDeferred;
            if (deferred != null)
            {
                deferred.m_opcode = opcode;
                deferred.m_location = argumentLocation;
                deferred.m_relativeTo = nextLocation;
                m_deferredArguments.Add(deferred);
                Console.WriteLine("Deferred: {0}", deferred);
            }
        }

        private void resolveDeferredArguments()
        {
            foreach (ArgumentDeferred deferred in m_deferredArguments)
            {
                ArgumentVisitor argumentVisitor = new ArgumentVisitor(m_equValues, allowDefer: false);
                Argument argument = argumentVisitor.Visit(deferred.m_context);

                int index = deferred.m_location;
                foreach (byte b in argument.generateBytes(deferred.m_opcode, deferred.m_relativeTo))
                {
                    Debug.Assert(m_objectCode[index] == 0xDF);
                    Console.WriteLine("{0:X2} -> {1:X2}", m_objectCode[index], b);
                    m_objectCode[index] = b;
                    index++;
                }
            }
        }
    }
}

