using Compiler.Scanner.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Compiler.Scanner.Regular
{
    /// <summary>
    /// 正则表达式基类,提供一些方法构建正则表达式
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public abstract class RegularExpression
    {
        public RegularExpressionType ExpressionType { get; private set; }
        protected RegularExpression(RegularExpressionType expType)
        {
            ExpressionType = expType;
        }
        /// <summary>
        /// 获取可压缩字符集合委托
        /// </summary>
        /// <returns>可压缩字符集委托方法集合</returns>
        internal abstract Func<HashSet<char>>[] GetCompactableCharSets();
        /// <summary>
        /// 获取不可压缩字符集
        /// </summary>
        /// <returns>不可压缩字符集合</returns>
        internal abstract HashSet<char> GetUncompactableCharSet();
        /// <summary>
        /// 获取转换后的类型值
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="converter">正则转换器</param>
        /// <returns>转换后的类型值</returns>
        internal abstract T Accept<T>(RegularExpressionConverter<T> converter);

        #region 一些基础方法操作
        public static RegularExpression Symbol(char c)
        {
            return new SymbolExpression(c);
        }
        public RegularExpression Many()
        {
            if (ExpressionType == RegularExpressionType.KleeneStar)
            {
                return this;
            }
            return new KleeneStarExpression(this);
        }
        public RegularExpression Concat(RegularExpression follow)
        {
            return new ConcatenationExpression(this, follow);
        }
        public RegularExpression Union(RegularExpression other)
        {
            if (this.Equals(other))
            {
                return this;
            }

            return new AlternationExpression(this, other);
        }
        public static RegularExpression Literal(string literal)
        {
            return new StringLiteralExpression(literal);
        }
        public static RegularExpression CharSet(params char[] charSet)
        {
            return new AlternationCharSetExpression(charSet);
        }
        public static RegularExpression Empty()
        {
            return EmptyExpression.Instance;
        }
        public RegularExpression Many1()
        {
            return this.Concat(this.Many());
        }
        public RegularExpression Optional()
        {
            return this.Union(Empty());
        }

        public static RegularExpression Range(char min, char max)
        {
            CodeContract.Requires(min <= max, "max", "The lower bound must be less than or equal to upper bound");

            List<char> rangeCharSet = new List<char>();
            for (char c = min; c <= max; c++)
            {
                rangeCharSet.Add(c);
            }

            return new AlternationCharSetExpression(rangeCharSet);
        }

        public static RegularExpression CharsOf(Func<char, bool> charPredicate)
        {
            CodeContract.RequiresArgumentNotNull(charPredicate, "charPredicate");

            List<char> charSet = new List<char>();
            for (int i = Char.MinValue; i <= Char.MaxValue; i++)
            {
                if (charPredicate((char)i)) charSet.Add((char)i);
            }

            return new AlternationCharSetExpression(charSet);
        }

        public RegularExpression Repeat(int number)
        {
            if (number <= 0)
            {
                return Empty();
            }

            RegularExpression result = this;

            for (int i = 1; i < number; i++)
            {
                result = result.Concat(this);
            }

            return result;
        }
        public static RegularExpression operator |(RegularExpression left, RegularExpression right)
        {
            return new AlternationExpression(left, right);
        }

        [SpecialName]
        public static RegularExpression op_RightShift(RegularExpression left, RegularExpression right)
        {
            return new ConcatenationExpression(left, right);
        }

        [SpecialName]
        public static RegularExpression op_Concatenate(RegularExpression left, RegularExpression right)
        {
            return new ConcatenationExpression(left, right);
        }
        #endregion
    }
}
