using System;
using System.Collections.Generic;
using System.Linq;

namespace Vectrasm
{
    public enum AddressingMode
    {
        Inherent, Direct, Indexed, Relative, Extended, Immediate, LongRelative
    }

    public class Opcode
    {
        public readonly int m_page, m_numOperands, m_numCycles;
        public readonly byte m_opcode;
        public readonly string m_name;
        public readonly AddressingMode m_addressingMode;

        public Opcode(int page, byte opcode, int numOperands, string name, AddressingMode addressingMode, int numCycles)
        {
            m_page = page;
            m_opcode = opcode;
            m_numOperands = numOperands;
            m_name = name.ToUpper();
            m_addressingMode = addressingMode;
            m_numCycles = numCycles;
        }

        public override string ToString()
        {
            return string.Format("[Opcode page={0} opcode={1:X2}/{1} numOperands={2} name={3} mode={4}]", m_page, m_opcode, m_numOperands, m_name, m_addressingMode);
        }

        public static List<Opcode> lookUpOpcode(string name)
        {
            name = name.ToUpper();
            return new List<Opcode>(from op in s_opcodes where op.m_name == name select op);
        }

        public static readonly List<Opcode> s_opcodes = new List<Opcode>(getAllOpcodes());

        private static IEnumerable<Opcode> getAllOpcodes()
        {
            yield return new Opcode(1, 0, 1, "neg", AddressingMode.Direct, 6);
            yield return new Opcode(1, 3, 1, "com", AddressingMode.Direct, 6);
            yield return new Opcode(1, 4, 1, "lsr", AddressingMode.Direct, 6);
            yield return new Opcode(1, 6, 1, "ror", AddressingMode.Direct, 6);
            yield return new Opcode(1, 7, 1, "asr", AddressingMode.Direct, 6);
            yield return new Opcode(1, 8, 1, "asl", AddressingMode.Direct, 6);
            yield return new Opcode(1, 9, 1, "rol", AddressingMode.Direct, 6);
            yield return new Opcode(1, 10, 1, "dec", AddressingMode.Direct, 6);
            yield return new Opcode(1, 12, 1, "inc", AddressingMode.Direct, 6);
            yield return new Opcode(1, 13, 1, "tst", AddressingMode.Direct, 6);
            yield return new Opcode(1, 14, 1, "jmp", AddressingMode.Direct, 3);
            yield return new Opcode(1, 15, 1, "clr", AddressingMode.Direct, 6);

            yield return new Opcode(1, 16, 1, "!page2", AddressingMode.Inherent, 0);
            yield return new Opcode(1, 17, 1, "!page3", AddressingMode.Inherent, 0);
            yield return new Opcode(1, 18, 0, "nop", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 19, 0, "sync", AddressingMode.Inherent, 4);
            yield return new Opcode(1, 22, 2, "lbra", AddressingMode.LongRelative, 5);
            yield return new Opcode(1, 23, 2, "lbsr", AddressingMode.LongRelative, 9);
            yield return new Opcode(1, 25, 0, "daa", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 26, 1, "orcc", AddressingMode.Immediate, 3);
            yield return new Opcode(1, 28, 1, "andcc", AddressingMode.Immediate, 3);
            yield return new Opcode(1, 29, 0, "sex", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 30, 1, "exg", AddressingMode.Immediate, 8);
            yield return new Opcode(1, 31, 1, "tfr", AddressingMode.Immediate, 6);

            yield return new Opcode(1, 32, 1, "bra", AddressingMode.Relative, 3);
            yield return new Opcode(1, 33, 1, "brn", AddressingMode.Relative, 3);
            yield return new Opcode(1, 34, 1, "bhi", AddressingMode.Relative, 3);
            yield return new Opcode(1, 35, 1, "bls", AddressingMode.Relative, 3);
            yield return new Opcode(1, 36, 1, "bcc", AddressingMode.Relative, 3);
            yield return new Opcode(1, 37, 1, "bcs", AddressingMode.Relative, 3);
            yield return new Opcode(1, 38, 1, "bne", AddressingMode.Relative, 3);
            yield return new Opcode(1, 39, 1, "beq", AddressingMode.Relative, 3);
            yield return new Opcode(1, 40, 1, "bvc", AddressingMode.Relative, 3);
            yield return new Opcode(1, 41, 1, "bvs", AddressingMode.Relative, 3);
            yield return new Opcode(1, 42, 1, "bpl", AddressingMode.Relative, 3);
            yield return new Opcode(1, 43, 1, "bmi", AddressingMode.Relative, 3);
            yield return new Opcode(1, 44, 1, "bge", AddressingMode.Relative, 3);
            yield return new Opcode(1, 45, 1, "blt", AddressingMode.Relative, 3);
            yield return new Opcode(1, 46, 1, "bgt", AddressingMode.Relative, 3);
            yield return new Opcode(1, 47, 1, "ble", AddressingMode.Relative, 3);

            yield return new Opcode(1, 48, 1, "leax", AddressingMode.Indexed, 2);
            yield return new Opcode(1, 49, 1, "leay", AddressingMode.Indexed, 2);
            yield return new Opcode(1, 50, 1, "leas", AddressingMode.Indexed, 2);
            yield return new Opcode(1, 51, 1, "leau", AddressingMode.Indexed, 2);
            yield return new Opcode(1, 52, 1, "pshs", AddressingMode.Inherent, 5);
            yield return new Opcode(1, 53, 1, "puls", AddressingMode.Inherent, 5);
            yield return new Opcode(1, 54, 1, "pshu", AddressingMode.Inherent, 5);
            yield return new Opcode(1, 55, 1, "pulu", AddressingMode.Inherent, 5);
            yield return new Opcode(1, 57, 0, "rts", AddressingMode.Inherent, 5);
            yield return new Opcode(1, 58, 0, "abx", AddressingMode.Inherent, 3);
            yield return new Opcode(1, 59, 0, "rti", AddressingMode.Inherent, 6);
            yield return new Opcode(1, 60, 1, "cwai", AddressingMode.Immediate, 20);
            yield return new Opcode(1, 61, 0, "mul", AddressingMode.Inherent, 11);
            yield return new Opcode(1, 63, 0, "swi", AddressingMode.Inherent, 19);

            yield return new Opcode(1, 64, 0, "nega", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 67, 0, "coma", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 68, 0, "lsra", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 70, 0, "rora", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 71, 0, "asra", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 72, 0, "asla", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 73, 0, "rola", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 74, 0, "deca", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 76, 0, "inca", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 77, 0, "tsta", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 79, 0, "clra", AddressingMode.Inherent, 2);

            yield return new Opcode(1, 80, 0, "negb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 83, 0, "comb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 84, 0, "lsrb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 86, 0, "rorb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 87, 0, "asrb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 88, 0, "aslb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 89, 0, "rolb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 90, 0, "decb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 92, 0, "incb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 93, 0, "tstb", AddressingMode.Inherent, 2);
            yield return new Opcode(1, 95, 0, "clrb", AddressingMode.Inherent, 2);

            yield return new Opcode(1, 96, 1, "neg", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 99, 1, "com", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 100, 1, "lsr", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 102, 1, "ror", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 103, 1, "asr", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 104, 1, "asl", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 105, 1, "rol", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 106, 1, "dec", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 108, 1, "inc", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 109, 1, "tst", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 110, 1, "jmp", AddressingMode.Indexed, 3);
            yield return new Opcode(1, 111, 1, "clr", AddressingMode.Indexed, 6);

            yield return new Opcode(1, 112, 2, "neg", AddressingMode.Extended, 7);
            yield return new Opcode(1, 115, 2, "com", AddressingMode.Extended, 7);
            yield return new Opcode(1, 116, 2, "lsr", AddressingMode.Extended, 7);
            yield return new Opcode(1, 118, 2, "ror", AddressingMode.Extended, 7);
            yield return new Opcode(1, 119, 2, "asr", AddressingMode.Extended, 7);
            yield return new Opcode(1, 120, 2, "asl", AddressingMode.Extended, 7);
            yield return new Opcode(1, 121, 2, "rol", AddressingMode.Extended, 7);
            yield return new Opcode(1, 122, 2, "dec", AddressingMode.Extended, 7);
            yield return new Opcode(1, 124, 2, "inc", AddressingMode.Extended, 7);
            yield return new Opcode(1, 125, 2, "tst", AddressingMode.Extended, 7);
            yield return new Opcode(1, 126, 2, "jmp", AddressingMode.Extended, 4);
            yield return new Opcode(1, 127, 2, "clr", AddressingMode.Extended, 7);

            yield return new Opcode(1, 128, 1, "suba", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 129, 1, "cmpa", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 130, 1, "sbca", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 131, 2, "subd", AddressingMode.Immediate, 4);
            yield return new Opcode(1, 132, 1, "anda", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 133, 1, "bita", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 134, 1, "lda", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 136, 1, "eora", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 137, 1, "adca", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 138, 1, "ora", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 139, 1, "adda", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 140, 2, "cmpx", AddressingMode.Immediate, 4);
            yield return new Opcode(1, 141, 1, "bsr", AddressingMode.Relative, 7);
            yield return new Opcode(1, 142, 2, "ldx", AddressingMode.Immediate, 3);

            yield return new Opcode(1, 144, 1, "suba", AddressingMode.Direct, 4);
            yield return new Opcode(1, 145, 1, "cmpa", AddressingMode.Direct, 4);
            yield return new Opcode(1, 146, 1, "sbca", AddressingMode.Direct, 4);
            yield return new Opcode(1, 147, 1, "subd", AddressingMode.Direct, 6);
            yield return new Opcode(1, 148, 1, "anda", AddressingMode.Direct, 4);
            yield return new Opcode(1, 149, 1, "bita", AddressingMode.Direct, 4);
            yield return new Opcode(1, 150, 1, "lda", AddressingMode.Direct, 4);
            yield return new Opcode(1, 151, 1, "sta", AddressingMode.Direct, 4);
            yield return new Opcode(1, 152, 1, "eora", AddressingMode.Direct, 4);
            yield return new Opcode(1, 153, 1, "adca", AddressingMode.Direct, 4);
            yield return new Opcode(1, 154, 1, "ora", AddressingMode.Direct, 4);
            yield return new Opcode(1, 155, 1, "adda", AddressingMode.Direct, 4);
            yield return new Opcode(1, 156, 1, "cpx", AddressingMode.Direct, 6);
            yield return new Opcode(1, 157, 1, "jsr", AddressingMode.Direct, 7);
            yield return new Opcode(1, 158, 1, "ldx", AddressingMode.Direct, 5);
            yield return new Opcode(1, 159, 1, "stx", AddressingMode.Direct, 5);

            yield return new Opcode(1, 160, 1, "suba", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 161, 1, "cmpa", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 162, 1, "sbca", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 163, 1, "subd", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 164, 1, "anda", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 165, 1, "bita", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 166, 1, "lda", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 167, 1, "sta", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 168, 1, "eora", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 169, 1, "adca", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 170, 1, "ora", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 171, 1, "adda", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 172, 1, "cpx", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 173, 1, "jsr", AddressingMode.Indexed, 7);
            yield return new Opcode(1, 174, 1, "ldx", AddressingMode.Indexed, 5);
            yield return new Opcode(1, 175, 1, "stx", AddressingMode.Indexed, 5);

            yield return new Opcode(1, 176, 2, "suba", AddressingMode.Extended, 5);
            yield return new Opcode(1, 177, 2, "cmpa", AddressingMode.Extended, 5);
            yield return new Opcode(1, 178, 2, "sbca", AddressingMode.Extended, 5);
            yield return new Opcode(1, 179, 2, "subd", AddressingMode.Extended, 7);
            yield return new Opcode(1, 180, 2, "anda", AddressingMode.Extended, 5);
            yield return new Opcode(1, 181, 2, "bita", AddressingMode.Extended, 5);
            yield return new Opcode(1, 182, 2, "lda", AddressingMode.Extended, 5);
            yield return new Opcode(1, 183, 2, "sta", AddressingMode.Extended, 5);
            yield return new Opcode(1, 184, 2, "eora", AddressingMode.Extended, 5);
            yield return new Opcode(1, 185, 2, "adca", AddressingMode.Extended, 5);
            yield return new Opcode(1, 186, 2, "ora", AddressingMode.Extended, 5);
            yield return new Opcode(1, 187, 2, "adda", AddressingMode.Extended, 5);
            yield return new Opcode(1, 188, 2, "cpx", AddressingMode.Extended, 7);
            yield return new Opcode(1, 189, 2, "jsr", AddressingMode.Extended, 8);
            yield return new Opcode(1, 190, 2, "ldx", AddressingMode.Extended, 6);
            yield return new Opcode(1, 191, 2, "stx", AddressingMode.Extended, 6);

            yield return new Opcode(1, 192, 1, "subb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 193, 1, "cmpb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 194, 1, "sbcb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 195, 2, "addd", AddressingMode.Immediate, 4);
            yield return new Opcode(1, 196, 1, "andb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 197, 1, "bitb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 198, 1, "ldb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 200, 1, "eorb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 201, 1, "adcb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 202, 1, "orb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 203, 1, "addb", AddressingMode.Immediate, 2);
            yield return new Opcode(1, 204, 2, "ldd", AddressingMode.Immediate, 3);
            yield return new Opcode(1, 206, 2, "ldu", AddressingMode.Immediate, 3);

            yield return new Opcode(1, 208, 1, "subb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 209, 1, "cmpb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 210, 1, "sbcb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 211, 1, "addd", AddressingMode.Direct, 6);
            yield return new Opcode(1, 212, 1, "andb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 213, 1, "bitb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 214, 1, "ldb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 215, 1, "stb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 216, 1, "eorb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 217, 1, "adcb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 218, 1, "orb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 219, 1, "addb", AddressingMode.Direct, 4);
            yield return new Opcode(1, 220, 1, "ldd", AddressingMode.Direct, 5);
            yield return new Opcode(1, 221, 1, "std", AddressingMode.Direct, 5);
            yield return new Opcode(1, 222, 1, "ldu", AddressingMode.Direct, 5);
            yield return new Opcode(1, 223, 1, "stu", AddressingMode.Direct, 5);

            yield return new Opcode(1, 224, 1, "subb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 225, 1, "cmpb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 226, 1, "sbcb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 227, 1, "addd", AddressingMode.Indexed, 6);
            yield return new Opcode(1, 228, 1, "andb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 229, 1, "bitb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 230, 1, "ldb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 231, 1, "stb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 232, 1, "eorb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 233, 1, "adcb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 234, 1, "orb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 235, 1, "addb", AddressingMode.Indexed, 4);
            yield return new Opcode(1, 236, 1, "ldd", AddressingMode.Indexed, 5);
            yield return new Opcode(1, 237, 1, "std", AddressingMode.Indexed, 5);
            yield return new Opcode(1, 238, 1, "ldu", AddressingMode.Indexed, 5);
            yield return new Opcode(1, 239, 1, "stu", AddressingMode.Indexed, 5);

            yield return new Opcode(1, 240, 2, "subb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 241, 2, "cmpb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 242, 2, "sbcb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 243, 2, "addd", AddressingMode.Extended, 7);
            yield return new Opcode(1, 244, 2, "andb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 245, 2, "bitb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 246, 2, "ldb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 247, 2, "stb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 248, 2, "eorb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 249, 2, "adcb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 250, 2, "orb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 251, 2, "addb", AddressingMode.Extended, 5);
            yield return new Opcode(1, 252, 2, "ldd", AddressingMode.Extended, 6);
            yield return new Opcode(1, 253, 2, "std", AddressingMode.Extended, 6);
            yield return new Opcode(1, 254, 2, "ldu", AddressingMode.Extended, 6);
            yield return new Opcode(1, 255, 2, "stu", AddressingMode.Extended, 6);

            yield return new Opcode(2, 33, 3, "lbrn", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 34, 3, "lbhi", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 35, 3, "lbls", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 36, 3, "lbcc", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 37, 3, "lbcs", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 38, 3, "lbne", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 39, 3, "lbeq", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 40, 3, "lbvc", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 41, 3, "lbvs", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 42, 3, "lbpl", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 43, 3, "lbmi", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 44, 3, "lbge", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 45, 3, "lblt", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 46, 3, "lbgt", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 47, 3, "lble", AddressingMode.LongRelative, 5);
            yield return new Opcode(2, 63, 1, "swi2", AddressingMode.Inherent, 20); /* chris changed numoperands from 2 to 1 */
            yield return new Opcode(2, 131, 3, "cmpd", AddressingMode.Immediate, 5);
            yield return new Opcode(2, 140, 3, "cmpy", AddressingMode.Immediate, 5);
            yield return new Opcode(2, 142, 3, "ldy", AddressingMode.Immediate, 4);
            yield return new Opcode(2, 147, 2, "cmpd", AddressingMode.Direct, 7);
            yield return new Opcode(2, 156, 2, "cmpy", AddressingMode.Direct, 7);
            yield return new Opcode(2, 158, 2, "ldy", AddressingMode.Direct, 6);
            yield return new Opcode(2, 159, 2, "sty", AddressingMode.Direct, 6);
            yield return new Opcode(2, 163, 2, "cmpd", AddressingMode.Indexed, 7);
            yield return new Opcode(2, 172, 2, "cmpy", AddressingMode.Indexed, 7);
            yield return new Opcode(2, 174, 2, "ldy", AddressingMode.Indexed, 6);
            yield return new Opcode(2, 175, 2, "sty", AddressingMode.Indexed, 6);
            yield return new Opcode(2, 179, 3, "cmpd", AddressingMode.Extended, 8);
            yield return new Opcode(2, 188, 3, "cmpy", AddressingMode.Extended, 8);
            yield return new Opcode(2, 190, 3, "ldy", AddressingMode.Extended, 7);
            yield return new Opcode(2, 191, 3, "sty", AddressingMode.Extended, 7);
            yield return new Opcode(2, 206, 3, "lds", AddressingMode.Immediate, 4);
            yield return new Opcode(2, 222, 2, "lds", AddressingMode.Direct, 6);
            yield return new Opcode(2, 223, 2, "sts", AddressingMode.Direct, 6);
            yield return new Opcode(2, 238, 2, "lds", AddressingMode.Indexed, 6);
            yield return new Opcode(2, 239, 2, "sts", AddressingMode.Indexed, 6);
            yield return new Opcode(2, 254, 3, "lds", AddressingMode.Extended, 7);
            yield return new Opcode(2, 255, 3, "sts", AddressingMode.Extended, 7);

            yield return new Opcode(3, 63, 1, "swi3", AddressingMode.Inherent, 20);
            yield return new Opcode(3, 131, 3, "cmpu", AddressingMode.Immediate, 5);
            yield return new Opcode(3, 140, 3, "cmps", AddressingMode.Immediate, 5);
            yield return new Opcode(3, 147, 2, "cmpu", AddressingMode.Direct, 7);
            yield return new Opcode(3, 156, 2, "cmps", AddressingMode.Direct, 7);
            yield return new Opcode(3, 163, 2, "cmpu", AddressingMode.Indexed, 7);
            yield return new Opcode(3, 172, 2, "cmps", AddressingMode.Indexed, 7);
            yield return new Opcode(3, 179, 3, "cmpu", AddressingMode.Extended, 8);
            yield return new Opcode(3, 188, 3, "cmps", AddressingMode.Extended, 8);
        }
    }
}
