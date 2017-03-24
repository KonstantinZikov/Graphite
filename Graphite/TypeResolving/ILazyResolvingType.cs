using System.Collections.Generic;

namespace Graphite
{
    /// <summary>
    /// Defines type that can be resolved to another types.
    /// </summary>
    public interface ILazyResolvingType : ITokenType
    {
        /// <summary>
        /// All types in which ILazyResolvingType can be recognized.
        /// </summary>
        ICollection<ITokenType> LeafTypes { get; }
    }
}
