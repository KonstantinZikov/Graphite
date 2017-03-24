namespace Graphite {
    export class LexicalAnalyzerOptions {

        private _allowSkiping: boolean;
        public get allowSkipping(): boolean {
            return this._allowSkiping;
        }
        public set allowSkipping(allowSkiping: boolean) {
            this._allowSkiping = allowSkiping;
        }

        private _compressWhitespaces: boolean;
        public get compressWhitespaces(): boolean {
            return this._compressWhitespaces;
        }
        public set compressWhitespaces(compressWhitespaces: boolean) {
            this._compressWhitespaces = compressWhitespaces;
        }
    }
}