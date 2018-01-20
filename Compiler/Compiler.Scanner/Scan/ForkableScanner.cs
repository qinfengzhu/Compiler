using Compiler.Scanner.Lex;
using System;
using System.Diagnostics;

namespace Compiler.Scanner.Scan
{
    public struct ForkableScanner
    {
        private Scanner m_masterScanner;
        private int m_offset;

        private ForkableScanner(Scanner masterScanner)
        {
            m_masterScanner = masterScanner;
            m_offset = 0;
        }

        public ScannerInfo ScannerInfo
        {
            get
            {
                if (m_masterScanner == null)
                {
                    throw new InvalidOperationException("The ForkableScanner instance is not valid. Please use ForkableScannerBuilder to create ForkableScanner.");
                }

                return m_masterScanner.ScannerInfo;
            }
        }

        internal static ForkableScanner Create(Scanner masterScanner)
        {
            return new ForkableScanner(masterScanner);
        }

        public Lexeme Read()
        {

            Lexeme result;
            Debug.Assert(m_offset <= m_masterScanner.History.Count);
            if (m_offset < m_masterScanner.History.Count)
            {
                //queue is available to fetch tokens
                result = m_masterScanner.History[m_offset];
            }
            else
            {
                result = m_masterScanner.Read();
            }

            m_offset += 1;
            return result;

        }

        public ForkableScanner Fork()
        {
            //copy instance
            return this;
        }

        public void Join(ForkableScanner scanner)
        {
            m_masterScanner = scanner.m_masterScanner;
            m_offset = scanner.m_offset;
        }
    }
}
