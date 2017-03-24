namespace Graphite
{
    /// <summary>
    /// Main struct which contains information about separated code part.
    /// </summary>
    public struct Token
    {
        /// <summary>
        /// Type of the token.
        /// </summary>
        public ITokenType Type { get; set; }
        /// <summary>
        /// Text part of the code, which was recognized as a token.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Number of the line in the code on which token value was placed.
        /// </summary>
        public int Line { get; set; }
    }
}
