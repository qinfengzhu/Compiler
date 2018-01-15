namespace Compiler.Scanner.Regular
{
    public enum RegularExpressionType
    {
        Empty,//空字符ε
        Symbol,//单个字符
        Alternation,//并运算
        Concatenation,//连接运算
        KleeneStar,//克林闭包
        AlternationCharSet,//多字符集并
        StringLiteral//一串常量字符串
    }
}
