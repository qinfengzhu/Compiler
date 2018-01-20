using Compiler.Scanner.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Compiler.Scanner.NFA
{
    /// <summary>
    /// NFA的状态
    /// </summary>
    [DebuggerDisplay("State #{Index}")]
    public class NFAState
    {
        private List<NFAEdge> m_outEdges;
        private ReadOnlyCollection<NFAEdge> m_readonlyOutEdges;

        internal NFAState()
        {
            m_outEdges = new List<NFAEdge>();
            m_readonlyOutEdges = new ReadOnlyCollection<NFAEdge>(m_outEdges);

            //default value -1 means no token is bound with this state
            TokenIndex = -1;
        }

        public int Index { get; internal set; }
        internal int TokenIndex { get; set; }

        public ReadOnlyCollection<NFAEdge> OutEdges
        {
            get
            {
                return m_readonlyOutEdges;
            }
        }

        internal void AddEmptyEdgeTo(NFAState targetState)
        {
            CodeContract.RequiresArgumentNotNull(targetState, "targetState");

            m_outEdges.Add(new NFAEdge(targetState));
        }

        internal void AddEdge(NFAEdge edge)
        {
            CodeContract.RequiresArgumentNotNull(edge, "edge");

            m_outEdges.Add(edge);
        }
    }
}
