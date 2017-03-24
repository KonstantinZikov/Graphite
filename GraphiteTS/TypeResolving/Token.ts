namespace Graphite{

    /** 
     * Main class which contains information about separated code part.
     */ 
    export class Token {

        /** 
         * Type of the token.
         */
        private _type: ITokenType;
        get type(): ITokenType { return this._type; }
        set type(type: ITokenType) { this.type = type; }

        /** 
         * Text part of the code, which was recognized as a token.
         */
        private _value: string;
        get value(): string { return this._value; }
        set value(value: string) { this.value = value; }

        /** 
         * Number of the line in the code on which token value was placed.
         */
        private _line: number;
        get line(): number { return this._line; }
        set line(line: number) { this._line = line; }
    }
}
