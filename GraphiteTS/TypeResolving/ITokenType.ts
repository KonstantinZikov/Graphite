namespace Graphite{

	/**
	 * Defines description of the token.
	 */
    export interface ITokenType {	
        	
		/**
		 * Check selected value for matching token type.
		 * @param {string} word - Value for matching.
		 * @returns {boolean} - Is value match token type.
		*/
        is(word: string): boolean;

		/**
		 * If this property is set to true, lexical analizer will remove it from returning token collection.
		*/
        readonly skip: boolean;
	}
}