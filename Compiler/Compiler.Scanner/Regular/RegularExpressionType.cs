namespace Compiler.Scanner.Regular
{
    public enum RegularExpressionType
    {
        Empty,//空字符ε ""
        Symbol,//单个字符   a
        Alternation,//并运算   a|b
        Concatenation,//连接运算 ab
        KleeneStar,//克林闭包 a*
        AlternationCharSet,//交替字符集合[abcd]
        StringLiteral//一串常量字符串 "abcd"
    }
}
