namespace Compiler.Scanner.DFA
{
    /// <summary>
    /// DFA的边
    /// </summary>
    public struct DFAEdge
    {
        public DFAEdge(int symbol, DFAState targetState)
            : this()
        {
            Symbol = symbol;
            TargetState = targetState;
        }

        public int Symbol { get; private set; }
        public DFAState TargetState { get; private set; }
    }
}
