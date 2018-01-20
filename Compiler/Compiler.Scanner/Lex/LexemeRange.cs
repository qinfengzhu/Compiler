using System;
using System.Collections.Generic;
using System.Collections;
using Compiler.Scanner.Common;

namespace Compiler.Scanner.Lex
{
    public class LexemeRange : IReadOnlyList<Lexeme>
    {
        private readonly int m_length;
        private readonly IReadOnlyList<Lexeme> m_lexemeList;
        private readonly int m_startIndex;
        
        public LexemeRange(IReadOnlyList<Lexeme> lexemeList,int startIndex,int length)
        {
            CodeContract.RequiresArgumentNotNull(lexemeList, "lexemeList");
            CodeContract.RequiresArgumentInRange(startIndex >= 0 && startIndex <= lexemeList.Count,
                "startIndex", "startIndex must be greater or equal to 0 and less than the count of lexemeList");
            CodeContract.RequiresArgumentInRange(length >= 0 && startIndex + length <= lexemeList.Count,
                "length", "lengh is invalid");

            m_lexemeList = lexemeList;
            m_startIndex = startIndex;
            m_length = length;
        }
        public Lexeme this[int index]
        {
            get
            {
                CodeContract.RequiresArgumentInRange(index >= 0 && index < m_length,
    "index", "index must be greater than or equal to 0 and less than the length of the range");
                return m_lexemeList[index + m_startIndex];
            }
        }

        public int Count
        {
            get
            {
                return m_length;
            }
        }

        public IEnumerator<Lexeme> GetEnumerator()
        {
            for(int i = m_startIndex; i < m_startIndex + m_length; i++)
            {
                yield return m_lexemeList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
