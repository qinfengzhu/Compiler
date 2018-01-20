using System;

namespace Compiler.Scanner.Scan
{
    /// <summary>
    /// 整理规范化扫描器信息
    /// </summary>
    internal struct SerializableScannerInfo
    {
        internal int[][] AcceptTables;//
        internal ushort[] CharClassTable;//等价类表
        internal int TokenCount;
        internal int[][] TransitionTable;//转换表

        internal SerializableScannerInfo(int[][] transitionTable,ushort[] charClassTable,int[][] acceptTables,int tokenCount)
        {
            TransitionTable = transitionTable;
            CharClassTable = charClassTable;
            AcceptTables = acceptTables;
            TokenCount = tokenCount;
        }
    }
}
