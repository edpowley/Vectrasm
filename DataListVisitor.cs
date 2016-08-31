using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Vectrasm
{
    public class DataListVisitor : AsmBaseVisitor<IEnumerable<byte>>
    {
        private ExpressionVisitor m_exprEvaluator;

        public DataListVisitor(Dictionary<string, int> constants)
        {
            m_exprEvaluator = new ExpressionVisitor(constants);
        }

        public override IEnumerable<byte> VisitDataWordList(AsmParser.DataWordListContext context)
        {
            foreach (var expr in context.expr())
            {
                int val = m_exprEvaluator.Visit(expr);
                short word = (short)val;
                byte hi = (byte)(word >> 8);
                byte lo = (byte)(word & 0xFF);
                yield return hi;
                yield return lo;
            }
        }

        public override IEnumerable<byte> VisitDataByteList(AsmParser.DataByteListContext context)
        {
            foreach (var data in context.data_byte())
                foreach (byte b in Visit(data))
                    yield return b;
        }

        public override IEnumerable<byte> VisitDataByteExpr(AsmParser.DataByteExprContext context)
        {
            int val = m_exprEvaluator.Visit(context.expr());
            yield return (byte)val;
        }

        public override IEnumerable<byte> VisitDataByteString(AsmParser.DataByteStringContext context)
        {
            string text = context.LITERAL_STRING().GetText();
            Debug.Assert(text[0] == '"' && text[text.Length - 1] == '"');
            text = text.Substring(1, text.Length - 2);

            return (from c in text select (byte)c);
        }

    }
}

