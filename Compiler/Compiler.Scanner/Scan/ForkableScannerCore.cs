using Compiler.Scanner.Common;
using Compiler.Scanner.Lex;

namespace Compiler.Scanner.Scan
{
    class ForkableScannerCore
    {
        internal readonly CacheQueue<Lexeme> LookAheadQueue;
        internal readonly Scanner MasterScanner;

        internal ForkableScannerCore(Scanner masterScanner)
        {
            MasterScanner = masterScanner;
            LookAheadQueue = new CacheQueue<Lexeme>();
        }
    }
}
