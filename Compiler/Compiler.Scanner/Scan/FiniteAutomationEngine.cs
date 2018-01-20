using System.Diagnostics;

namespace Compiler.Scanner.Scan
{
    class FiniteAutomationEngine
    {
        private ushort[] m_charClassTable;
        private int m_currentState;
        private int[][] m_transitionTable;

        public FiniteAutomationEngine(int[][] transitionTable, ushort[] charClassTable)
        {
            m_transitionTable = transitionTable;
            m_charClassTable = charClassTable;

            Debug.Assert(m_transitionTable.Length > 0);

            m_currentState = 1;
        }

        public int CurrentState
        {
            get
            {
                return m_currentState;
            }
        }

        public bool IsAtStoppedState
        {
            get
            {
                return m_currentState == 0;
            }
        }

        public void Reset()
        {
            m_currentState = 1;
        }

        public void Input(char c)
        {
            int[] transitions = m_transitionTable[m_currentState];
            //find out which is the next state
            ushort charClass = m_charClassTable[c];
            int nextState = transitions[charClass];

            //go to next state
            m_currentState = nextState;
        }

        public void InputString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Input(str[i]);
            }
        }
    }
}
