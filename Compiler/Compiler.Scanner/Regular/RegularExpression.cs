using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Compiler.Scanner.Regular
{
    /// <summary>
    /// 正则表达式基类,提供一些方法构建正则表达式
    /// </summary>
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

        }
        #endregion
    }
}
