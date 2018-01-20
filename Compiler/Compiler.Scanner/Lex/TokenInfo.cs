using Compiler.Scanner.NFA;
using Compiler.Scanner.Regular;
using System;
using System.Diagnostics;

namespace Compiler.Scanner.Lex
{
    [DebuggerDisplay("Index: {Tag.Index} {Tag.ToString()}")]
    public class TokenInfo
    {
        public Token Tag { get; private set; }
        public Lexicon Lexicon { get; private set; }
        public Lexer State { get; private set; }
        public RegularExpression Definition { get; private set; }

        internal TokenInfo(RegularExpression definition,Lexicon lexicon,Lexer state,Token tag)
        {
            Lexicon = lexicon;
            Definition = definition;
            State = state;

            Tag = tag;
        }
        public NFAModel CreateFiniteAutomatonModel(NFAConverter converter)
        {
            NFAModel nfa = converter.Convert(Definition);

            Debug.Assert(nfa.TailState != null);

            nfa.TailState.TokenIndex = Tag.Index;

            return nfa;
        }
    }
}
