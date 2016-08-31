using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Vectrasm
{
    public abstract class Argument
    {
        public readonly AddressingMode m_mode;

        public Argument(AddressingMode mode)
        {
            m_mode = mode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(GetType().Name);

            foreach (var field in GetType().GetFields())
            {
                sb.AppendFormat(" {0} = {1}", field.Name, field.GetValue(this));
            }

            sb.Append("]");
            return sb.ToString();
        }

        public abstract IEnumerable<byte> generateBytes(Opcode opcode, int relativeTo);
    }

    public class ArgumentInherent : Argument
    {
        public ArgumentInherent()
            : base(AddressingMode.Inherent)
        {
        }

        public override IEnumerable<byte> generateBytes(Opcode opcode, int relativeTo)
        {
            if (opcode.m_numOperands > 0)
            {
                throw new InvalidOperationException("Inherent argument cannot generate >0 bytes");
            }

            return Enumerable.Empty<byte>();
        }
    }

    public class ArgumentWithValue : Argument
    {
        public readonly int m_value;

        public ArgumentWithValue(AddressingMode mode, int val)
            : base(mode)
        {
            m_value = val;
        }

        public override IEnumerable<byte> generateBytes(Opcode opcode, int relativeTo)
        {
            int value = m_value;

            if (opcode.m_addressingMode == AddressingMode.Relative || opcode.m_addressingMode == AddressingMode.LongRelative)
            {
                value = value - relativeTo;
            }

            switch (opcode.m_numOperands)
            {
                case 1:
                    yield return (byte)value;
                    break;

                case 2:
                    yield return (byte)(value >> 8);
                    yield return (byte)(value & 0xFF);
                    break;

                default:
                    throw new InvalidOperationException("Cannot generate bla");
            }
        }
    }

    public class ArgumentDeferred : Argument
    {
        public readonly AsmParser.ArgumentContext m_context;

        public Opcode m_opcode;
        public int m_location, m_relativeTo;

        public ArgumentDeferred(AddressingMode mode, AsmParser.ArgumentContext context)
            : base(mode)
        {
            m_context = context;
        }

        public override IEnumerable<byte> generateBytes(Opcode opcode, int relativeTo)
        {
            for (int i = 0; i < opcode.m_numOperands; i++)
            {
                yield return 0xDF;
            }
        }
    }
}

