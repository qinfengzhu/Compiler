using Compiler.Scanner.Common;
using System;
namespace Compiler.Scanner.Lex
{
    /// <summary>
    /// 词素值
    /// </summary>
    public sealed class LexemeValue
    {
        public LexemeValue(string content,SourceSpan span)
        {
            CodeContract.RequiresArgumentNotNull(span, "span");

            Content = content;
            Span = span;
        }

        public string Content { get; private set; }
        public SourceSpan Span { get; private set; }
        public override string ToString()
        {
            return Content;
        }
    }
    public static class LexemeExtensions
    {
        public static LexemeValue GetValue(this Lexeme lexeme)
        {
            if(lexeme!=null)
            {
                return lexeme.Value;
            }
            else
            {
                return null;
            }
        }
    }

}
