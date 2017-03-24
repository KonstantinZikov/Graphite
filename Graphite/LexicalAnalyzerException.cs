using System;

namespace Graphite
{
    public class LexicalAnalyzerException : Exception
    {
        public LexicalAnalyzerException() : base() { }
        public LexicalAnalyzerException(string message) : base(message) { }
        public LexicalAnalyzerException(string message, Exception innerException) : base(message, innerException) { }
    }
}

