using System;

namespace Compiler.Scanner
{
    [Serializable]
    public class ScannerException : Exception
    {
        public ScannerException() { }
        public ScannerException(string message) : base(message) { }
        public ScannerException(string message, Exception inner) : base(message, inner) { }
        protected ScannerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
