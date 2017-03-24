import ILazyResolvingType from "./Graphite";

namespace Graphite.Implementations
{
    export class LazyResolvingType implements Graphite.ILazyResolvingType
    {
        private readonly _rootType: ITokenType;
        private readonly _leafTypes: ITokenType[];

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

        public is(word:string):bool {
            return _rootType.is(word);
        }

    }
}
