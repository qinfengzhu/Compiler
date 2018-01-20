using System;

namespace Compiler.Scanner.Lex
{
    /// <summary>
    /// Token->关键字，或者ID或者其他的识别符定义
    /// </summary>
    public class Token : IEquatable<Token>
    {
        public int Index { get; private set; }
        public int LexerIndex { get; private set; }
        public string Description { get; private set; }

        public Token(int index,string description,int lexerIndex)
        {
            Index = index;
            Description = description;
            LexerIndex = lexerIndex;
        }
        public bool Equals(Token other)
        {
            if(other==null)
            {
                return false;
            }
            return Index == other.Index;
        }
        public override int GetHashCode()
        {
            return Index;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Token);
        }
        public override string ToString()
        {
            return Description;
        }
    }
}
