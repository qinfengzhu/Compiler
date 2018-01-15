using System;
using System.Collections.Generic;

namespace Compiler.Scanner.Regular
{
    public sealed class KleeneStarExpression:RegularExpression
    {
        public KleeneStarExpression(RegularExpression innerExp)
            : base(RegularExpressionType.KleeneStar)
        {
            
        }
    }
}
