using Compiler.Scanner.Common;
using Compiler.Scanner.Lex;
using System;

namespace Compiler.Scanner.Scan
{
    /// <summary>
    /// 扫描器信息
    /// </summary>
    public class ScannerInfo
    {
        private SerializableScannerInfo m_detail;
        private int m_lexerState;

        internal ScannerInfo(int[][] transitionTable,ushort[] charClassTable,int[][] acceptTables,int tokenCount)
        {
            m_detail = new SerializableScannerInfo(transitionTable, charClassTable, acceptTables, tokenCount);
            EndOfStreamTokenIndex = tokenCount;
        }
        public int EndOfStreamTokenIndex { get; private set; }

        internal int[][] TransitionTable
        {
            get { return m_detail.TransitionTable; }
        }
        internal ushort[] CharClassTable
        {
            get { return m_detail.CharClassTable; }
        }
        internal int TokenCount
        {
            get { return m_detail.TokenCount; }
        }
        internal int EndOfStreamState
        {
            get { return m_detail.TransitionTable.Length; }
        }
        public int LexerStateCount
        {
            get { return m_detail.AcceptTables.Length; }
        }
        public int CurrentLexerIndex
        {
            get
            {
                return m_lexerState;
            }
            set
            {
                CodeContract.RequiresArgumentInRange(value >= 0 && value < m_detail.AcceptTables.Length, "value", "Invalid lexer index");
                m_lexerState = value;
            }
        }
        internal int GetStateIndex(int tokenIndex)
        {
            int possibleIndex = -1;
            for(int i=0;i<m_detail.AcceptTables.Length;i++)
            {
                possibleIndex = Array.IndexOf(m_detail.AcceptTables[i], tokenIndex);
                if(possibleIndex>=0)
                {
                    break;
                }
            }
            return possibleIndex;
        }
        internal int GetStateIndex(int tokenIndex,int state)
        {
            return Array.IndexOf(m_detail.AcceptTables[state], tokenIndex);
        }
        internal int GetTokenIndex(int state)
        {
            return m_detail.AcceptTables[m_lexerState][state];
        }
        internal int GetTokenIndex(int state,int lexerState)
        {
            return m_detail.AcceptTables[lexerState][state];
        }
    }
}
