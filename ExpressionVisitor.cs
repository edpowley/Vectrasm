using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Vectrasm
{
    public class UnknownIdentifierException : Exception
    {
        public UnknownIdentifierException(string id)
            : base("Unknown identifier '" + id + "'")
        {
        }
    }

    public class ExpressionVisitor : AsmBaseVisitor<int>
    {
        private Dictionary<string, int> m_constants;

        public ExpressionVisitor(Dictionary<string, int> constants)
        {
            m_constants = constants;
        }

        public override int VisitExprIdentifier(AsmParser.ExprIdentifierContext context)
        {
            string key = context.IDENTIFIER().GetText();
            if (m_constants.ContainsKey(key))
                return m_constants[key];
            else
                throw new UnknownIdentifierException(key);
        }

        public override int VisitExprUnaryOp(AsmParser.ExprUnaryOpContext context)
        {
            int rhs = Visit(context.rhs);
            switch (context.oper.Text)
            {
                case "+": return rhs;
                case "-": return -rhs;
                default: throw new InvalidOperationException("Unsupported unary operator");
            }
        }

        public override int VisitLiteralHex(AsmParser.LiteralHexContext context)
        {
            string text = context.LITERAL_HEX().GetText();
            Debug.Assert(text[0] == '$');
            text = text.Substring(1);

            return int.Parse(text, System.Globalization.NumberStyles.HexNumber);
        }

        public override int VisitLiteralDec(AsmParser.LiteralDecContext context)
        {
            string text = context.LITERAL_DEC().GetText();

            return int.Parse(text);
        }
    }
}

