using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Compiler.Scanner.NFA
{
    /// <summary>
    /// NFA模型
    /// </summary>
    public class NFAModel
    {
        private ReadOnlyCollection<NFAState> m_readonlyStates;
        private List<NFAState> m_states;

        internal NFAModel()
        {
            m_states = new List<NFAState>();
            m_readonlyStates = new ReadOnlyCollection<NFAState>(m_states);
        }

        public NFAState TailState { get; internal set; }
        public NFAEdge EntryEdge { get; internal set; }

        public ReadOnlyCollection<NFAState> States
        {
            get
            {
                return m_readonlyStates;
            }
        }
        internal void AddState(NFAState state)
        {
            m_states.Add(state);
            state.Index = m_states.Count - 1;
        }
        internal void AddStates(IEnumerable<NFAState> states)
        {
            foreach (var s in states)
            {
                AddState(s);
            }
        }
    }
}
