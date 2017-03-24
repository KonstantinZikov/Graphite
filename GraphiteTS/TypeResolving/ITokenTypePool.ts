namespace Graphite {

	/**
	 * Contains all token types for lexical analizer.
	 */
    export interface ITokenTypePool {

        /**
	    * That token type will be recognized as next-line expression and will be used for the counting of the lines.
	    */
        readonly nextLine: ITokenType;

        /**
	    * This tokens will be recognized in default order.
	    */
        readonly FastResolvingTypes: ITokenType[];

        /**
	     * Any element of this collection contains lazy-resolving-tokenType and another token types,
         * in which lazy-type can be resolved (looks like inheritance).
         * Final recognizing of this tokens will be delayed to the end of analyzing.
         * It helpful when a few TokenTypes can be grouped by separated symptoms.
	     */
        readonly LazyResolvingTypes: ILazyResolvingType[];
    }
}