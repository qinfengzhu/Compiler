using System;
using System.Collections.Generic;
using System.Globalization;

namespace Compiler.Scanner.Regular
{
    /// <summary>
    /// 单个字符正则表达式
    /// </summary>
    public class SymbolExpression:RegularExpression
    {
        public new char Symbol { get; private set; }
        public SymbolExpression(char symbol)
            :base(RegularExpressionType.Symbol)
        {
            Symbol = symbol;
        }
        public override string ToString()
        {
            return Symbol.ToString(CultureInfo.InvariantCulture);
        }
        internal override Func<HashSet<char>>[] GetCompactableCharSets()
        {
            return new Func<HashSet<char>>[0];
        }
        internal override HashSet<char> GetUncompactableCharSet()
        {
            var result = new HashSet<char> { Symbol };
            return result;
        }
        internal override T Accept<T>(RegularExpressionConverter<T> converter)
        {
            return converter.ConvertSymbol(this);
        }
    }
}
