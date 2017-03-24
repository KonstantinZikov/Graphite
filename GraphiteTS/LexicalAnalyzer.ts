namespace Graphite {

    export class LexicalAnalyzer {

        private readonly  _types: ITokenTypePool;
        private readonly  _options: LexicalAnalyzerOptions;
     
        constructor(typePool: ITokenTypePool, options?: LexicalAnalyzerOptions) {
            this._types = typePool;
            if (options) {
                this._options = options;
            }
            else {
                this._options = new LexicalAnalyzerOptions();
                this._options.allowSkipping = true;
                this._options.compressWhitespaces = true;
            }          
        }

        public analize(code:string): Token[] {
            if (this._options.compressWhitespaces) {
                code = this.normilizeLines(code);
                code = this.compressWhitespaces(code);
            }

            var tokens = this.divideToTokens(code);
            for (let i = 0; i < tokens.length; i++)
            {
                let resolvingType = tokens[i].type as ILazyResolvingType;
                if (resolvingType != null) {
                    this.resolveIdentifier(tokens[i], resolvingType);
                }
            }

            return tokens;
        }

        private normilizeLines(code: string): string {
            return code.replace("\r\n", "\n");
        }

        private compressWhitespaces(code: string): string{
            let result: string;
            let isWhitespace: boolean = false;
            let isNextLine: boolean = false;
            for (let i = 0; i < code.length; i++)
            {
                if (this.isWhiteSpace(code[i])) {
                    if (code[i] == '\n') {
                        isNextLine = true;
                    }
                    else {
                        isWhitespace = true;
                    }
                }
                else {
                    if (isNextLine) {
                        result += '\n';
                    }
                    else {
                        if (isWhitespace) {
                            result += ' ';
                        }
                    }

                    result += code[i];
                    isWhitespace = isNextLine = false;
                }
            }

            return result;
        }

        private divideToTokens(code: string): Token[]{
            let result: Token[] = new Array<Token>();
            let word = "";
            let position = 0;
            let types = this._types.FastResolvingTypes.concat(this._types.LazyResolvingTypes as ITokenType[]);
            let match = false;
            let lastType: ITokenType = null;
            let lineNumber = 1;
            while (position < code.length) {
                word += code[position];
                match = false;
                for(let type of types)
                {
                    if (type.is(word)) {
                        lastType = type;
                        match = true;
                        break;
                    }
                }

                if (!match && lastType != null) {
                    if (!(lastType.skip && this._options.allowSkipping)) {
                        let element: Token = new Token();
                        element.type = lastType;
                        element.value = word.substring(0, word.length - 1);
                        element.line = lineNumber;
                        result.push(element);
                    }

                    if (lastType == this._types.nextLine) {
                        lineNumber++;
                    }

                    lastType = null;
                    word = "";
                }
                else {
                    position++;
                }
            }

        if (lastType == null) {
            let message = "";
            if (result.length == 0) {
                message = "Unknown token in code start position.";
            }
            else {
                var token = result[result.length - 1];
                message = "Unknown token after element " + token.value + " at line " + token.line + ".";
            }

            throw new Error(message);
        }

        if (!(lastType.skip && this._options.allowSkipping)) {
            let element: Token = new Token();
            element.type = lastType;
            element.value = word;
            element.line = lineNumber;
            result.push(element);
        }

        return result;
    }

        private resolveIdentifier(token:Token, resolvingType:ILazyResolvingType){
            for (let type of resolvingType.LeafTypes)
            {
                if (type.is(token.value)) {
                    token.type = type;
                    return;
                }
            }
        }

        private isWhiteSpace(str: string): boolean {
            return str.match(/^ *$/) !== null;
        }
}
}