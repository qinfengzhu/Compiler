
namespace Compiler.Scanner.Regular
{
    /// <summary>
    /// 将正则表达式转换为另一种类型值的抽象类
    /// </summary>
    /// <typeparam name="T">正则表达式预转换的另一种值</typeparam>
    public abstract class RegularExpressionConverter<T>
    {
        protected RegularExpressionConverter() { }
        public T Convert(RegularExpression expression)
        {
            if (expression == null)
            {
                return default(T);
            }
            return expression.Accept(this);
        }
        public abstract T ConvertAlternation(AlternationExpression exp);
        public abstract T ConvertSymbol(SymbolExpression exp);
        public abstract T ConvertEmpty(EmptyExpression exp);
        public abstract T ConvertConcatenation(ConcatenationExpression exp);
        public abstract T ConvertAlternationCharSet(AlternationCharSetExpression exp);
        public abstract T ConvertStringLiteral(StringLiteralExpression exp);
        public abstract T ConvertKleeneStar(KleeneStarExpression exp);
    }
}
