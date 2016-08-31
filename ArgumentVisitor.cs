using System;
using System.Collections.Generic;

namespace Vectrasm
{
    public class ArgumentVisitor : AsmBaseVisitor<Argument>
    {
        private ExpressionVisitor m_exprEvaluator;
        private bool m_allowDefer;

        public ArgumentVisitor(Dictionary<string, int> constants, bool allowDefer)
        {
            m_exprEvaluator = new ExpressionVisitor(constants);
            m_allowDefer = allowDefer;
        }

        public override Argument VisitArgumentImmediate(AsmParser.ArgumentImmediateContext context)
        {
            try
            {
                int val = m_exprEvaluator.Visit(context.expr());
                return new ArgumentWithValue(AddressingMode.Immediate, val);
            }
            catch (UnknownIdentifierException)
            {
                if (m_allowDefer)
                    return new ArgumentDeferred(AddressingMode.Immediate, context);
                else
                    throw;
            }
        }

        public override Argument VisitArgumentExtendedOrDirect(AsmParser.ArgumentExtendedOrDirectContext context)
        {
            try
            {
                int val = m_exprEvaluator.Visit(context.expr());
                // TODO: infer type rather than checking value?
                //if (val >= 0 && val < 256)
                //    return new ArgumentWithValue(AddressingMode.Direct, val);
                //else
                    return new ArgumentWithValue(AddressingMode.Extended, val);
            }
            catch (UnknownIdentifierException)
            {
                if (m_allowDefer)
                    return new ArgumentDeferred(AddressingMode.Extended, context);
                else
                    throw;
            }
        }
    }
}

