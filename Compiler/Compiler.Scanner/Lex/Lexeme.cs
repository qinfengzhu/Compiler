using Compiler.Scanner.Common;
using Compiler.Scanner.Scan;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Compiler.Scanner.Lex
{
    /// <summary>
    /// 词素
    /// </summary>
    [DebuggerDisplay("Token:{TokenIndex} {Value.ToString()}")]
    public sealed class Lexeme
    {
        private static readonly Lexeme[] s_emptyTrivia = new Lexeme[0];

        private ScannerInfo m_scannerInfo;
        private int m_stateIndex;
        private IReadOnlyList<Lexeme> m_trivia;

        internal Lexeme(ScannerInfo scannerInfo,int state,SourceSpan span,string content)
        {
            m_scannerInfo = scannerInfo;
            m_stateIndex = state;
            Value = new LexemeValue(content, span);

            m_trivia = s_emptyTrivia;
        }
        public LexemeValue Value { get; private set; }

        public SourceSpan Span
        {
            get
            {
                return Value.Span;
            }
        }

        public string ToContentString()
        {
            return Value.ToString();
        }

        public int TokenIndex
        {
            get
            {
                if (m_scannerInfo == null)
                {
                    throw new InvalidOperationException("This lexeme is not initialized.");
                }
                return m_scannerInfo.GetTokenIndex(m_stateIndex);
            }
        }
        public IReadOnlyList<Lexeme> PrefixTrivia
        {
            get
            {
                return m_trivia;
            }
        }
        public bool IsEndOfStream
        {
            get
            {
                if (m_scannerInfo == null)
                {
                    throw new InvalidOperationException("This lexeme is not initialized");
                }
                return m_stateIndex == m_scannerInfo.EndOfStreamState;
            }
        }
        internal void SetTrivia(IReadOnlyList<Lexeme> trivia)
        {
            m_trivia = trivia;
        }
        public int GetTokenIndex(int lexerState)
        {
            if(m_scannerInfo==null)
            {
                throw new InvalidOperationException("This lexeme is not initialized");
            }
            return m_scannerInfo.GetTokenIndex(m_stateIndex, lexerState);
        }
        public Lexeme GetErrorCorrectionLexeme(int exprectedTokenIndex,string expectedValue)
        {
            if(m_scannerInfo==null)
            {
                throw new InvalidOperationException("This lexeme is not initialized");
            }
            int state = m_scannerInfo.GetStateIndex(exprectedTokenIndex);
            if (state < 0) throw new ArgumentException("Expected token index is invalid", "expectedTokenIndex");
            return new Lexeme(m_scannerInfo, state, new SourceSpan(Value.Span.StartLocation, Value.Span.StartLocation), expectedValue);
        }
        public static Lexeme CreateEmptyLexeme()
        {
            return new Lexeme(null, 0, new SourceSpan(new SourceLocation(), new SourceLocation()), null);
        }
    }
}
