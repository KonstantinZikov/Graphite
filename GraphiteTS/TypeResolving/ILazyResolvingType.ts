namespace Graphite {
    /**
    * Defines type that can be resolved to another types.
    */
    export interface ILazyResolvingType extends ITokenType
    {

        /**
        * All types in which ILazyResolvingType can be recognized.
        */
        readonly LeafTypes: ITokenType[];
    }
}