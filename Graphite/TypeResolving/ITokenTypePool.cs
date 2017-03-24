using System.Collections.Generic;

namespace Graphite
{
    /// <summary>
    /// Contains all token types for lexical analizer.
    /// </summary>
    public interface ITokenTypePool
    {
        /// <summary>
        /// That token type will be recognized as next-line expression and will be used for the counting of the lines.
        /// </summary>
        ITokenType NextLine { get; }
        /// <summary>
        /// This tokens will be recognized in default order.
        /// </summary>
        ICollection<ITokenType> FastResolvingTypes { get; }

        /// <summary>
        /// Any element of this collection contains lazy-resolving-tokenType and another token types,
        /// in which lazy-type can be resolved (looks like inheritance).
        /// Final recognizing of this tokens will be delayed to the end of analyzing.
        /// It helpful when a few TokenTypes can be grouped by separated symptoms.
        /// </summary>
        ICollection<ILazyResolvingType> LazyResolvingTypes { get; }
    }
}
