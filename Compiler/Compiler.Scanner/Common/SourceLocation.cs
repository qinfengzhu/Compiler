using System;

namespace Compiler.Scanner.Common
{
    /// <summary>
    /// 源代码的位置
    /// </summary>
    public struct SourceLocation : IEquatable<SourceLocation>, IComparable<SourceLocation>
    {
        public SourceLocation(int index,int line,int column)
            :this()
        {
            CharIndex = index;
            Line = line;
            Column = column;
        }
        public int Line { get; internal set; }
        public int Column { get; internal set; }
        public int CharIndex { get; internal set; }
        public int CompareTo(SourceLocation other)
        {
            var lineDiff = Line - other.Line;
            if (lineDiff > 0)
            {
                return 1;
            }
            if (lineDiff < 0)
            {
                return -1;
            }
            //行相同，就比较列
            var columnDiff = Column - other.Column;
            if (columnDiff > 0)
            {
                return 1;
            }
            if (columnDiff < 0)
            {
                return -1;
            }
            return 0;
        }

        public bool Equals(SourceLocation other)
        {
            return CharIndex == other.CharIndex && Line == other.Line && Column == other.Column;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var other = (SourceLocation)obj;
            return Equals(other);
        }

        public override string ToString()
        {
            return string.Format("(Char index: {0}, Line: {1} , Column: {2}", CharIndex, Line, Column);
        }

        public override int GetHashCode()
        {
            //移位操作大于异或操作 int是32位
            //Column*2*2*2*2
            //CharIndex*2*2*2*2*2*2*2*2
            return Line ^ Column << 4 ^ CharIndex << 8;
        }
    }
}
