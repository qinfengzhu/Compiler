using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Compiler.Scanner.DFA
{
    /// <summary>
    /// DFA状态
    /// </summary>
    public class DFAState
    {
        private HashSet<int> m_nfaStateSet;
        private List<DFAEdge> m_outEdges;

        internal DFAState()
        {
            m_outEdges = new List<DFAEdge>();
            m_nfaStateSet = new HashSet<int>();
        }

        public int Index { get; internal set; }

        public ReadOnlyCollection<DFAEdge> OutEdges
        {
            get
            {
                return m_outEdges.AsReadOnly();
            }
        }

        public ISet<int> NFAStateSet
        {
            get
            {
                return m_nfaStateSet;
            }
        }

        internal void AddEdge(DFAEdge edge)
        {
            CodeContract.RequiresArgumentNotNull(edge, "edge");

            m_outEdges.Add(edge);
        }
    }
}
