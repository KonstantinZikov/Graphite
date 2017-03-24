namespace Graphite
{
    /// <summary>
    /// Defines description of the token.
    /// </summary>
    public interface ITokenType
    {
        /// <summary>
        /// Check selected value for matching token type.
        /// </summary>
        /// <param name="word">Value for matching.</param>
        /// <returns>Is value match token type.</returns>
        bool Is(string word);

        /// <summary>
        /// If this property is set to true, 
        /// lexical analizer will remove it from returning token collection; 
        /// </summary>
        bool Skip { get; }
    }
}
