using System;
using System.IO;
using Antlr4.Runtime;

namespace Vectrasm
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string code = File.ReadAllText("/Volumes/exFat/Vectrex/hello2.asm");

            AntlrInputStream stream = new AntlrInputStream(code);
            AsmLexer lexer = new AsmLexer(stream);
            //lexer.AddErrorListener(new LexerErrorListener());
            CommonTokenStream tokens = new CommonTokenStream(lexer);

            AsmParser parser = new AsmParser(tokens);
            //parser.AddErrorListener(new ParserErrorListener());
            AsmParser.ProgContext tree;
            tree = parser.prog();

            AsmVisitor visitor = new AsmVisitor();
            visitor.Visit(tree);

            foreach (byte b in visitor.m_objectCode)
            {
                Console.Write("{0:X2} ", b);
            }

            File.WriteAllBytes("/Volumes/exFat/Vectrex/hello2.bin", visitor.m_objectCode.ToArray());
        }
    }
}
