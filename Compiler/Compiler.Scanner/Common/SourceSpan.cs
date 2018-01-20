using System;
namespace Compiler.Scanner.Common
{
    /// <summary>
    /// 源代码块,主要表示一个Lexeme 词素的块内容
    /// </summary>
    public class SourceSpan : IEquatable<SourceSpan>
    {
        private readonly SourceLocation m_startLocation;
        private readonly SourceLocation m_endLocation;
        
        public SourceSpan(SourceLocation startLocation,SourceLocation endLocation)
        {
            m_startLocation = startLocation;
            m_endLocation = endLocation;
        }
        public SourceLocation StartLocation
        {
            get { return m_startLocation; }
        }
        public SourceLocation EndLocation
        {
            get { return m_endLocation; }
        }
        public bool Equals(SourceSpan other)
        {
            if (other == null)
                return false;
            return m_startLocation.Equals(other.m_startLocation) &&
                m_endLocation.Equals(other.m_endLocation);
        }
        public override int GetHashCode()
        {
            return (m_endLocation.GetHashCode() << 16) ^ m_startLocation.GetHashCode();
        }
    }
}
