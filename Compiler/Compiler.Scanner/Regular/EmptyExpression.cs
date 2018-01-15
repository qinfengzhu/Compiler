using System;
using System.Collections.Generic;

namespace Compiler.Scanner.Regular
{
    /// <summary>
    /// 空字符表达式
    /// </summary>
    public sealed class EmptyExpression : RegularExpression
    {
        public static readonly EmptyExpression Instance = new EmptyExpression();
        private EmptyExpression() : base(RegularExpressionType.Empty) { }

        public override string ToString()
        {
            return "ε";
        }

        internal override Func<HashSet<char>>[] GetCompactableCharSets()
        {
            return new Func<HashSet<char>>[0];
        }

        internal override HashSet<char> GetUncompactableCharSet()
        {
            return new HashSet<char>();
        }

        internal override T Accept<T>(RegularExpressionConverter<T> converter)
        {
            return converter.ConvertEmpty(this);
        }
    }
}
