using System;
using System.Collections.Generic;

namespace Graphite.Implementations
{
    public class LazyResolvingType : ILazyResolvingType
    {
        private readonly ITokenType _rootType;
        private readonly ICollection<ITokenType> _leafTypes;

        public LazyResolvingType(ITokenType rootType, ICollection<ITokenType> leafTypes)
        {
            if (rootType == null)
            {
                throw new ArgumentNullException($"{nameof(rootType)} is null.");
            }

            if (leafTypes == null)
            {
                throw new ArgumentNullException($"{nameof(leafTypes)} is null.");
            }
                
            _rootType = rootType;          
            _leafTypes = leafTypes;
        }

        public ICollection<ITokenType> LeafTypes
        {
            get{ return _leafTypes; }
        }

        public bool Skip
        {
            get{ return _rootType.Skip; }
        }

        public bool Is(string word)
            => _rootType.Is(word);
    }
}
