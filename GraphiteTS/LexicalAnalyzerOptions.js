var Graphite;
(function (Graphite) {
    class LexicalAnalyzerOptions {
        get allowSkipping() {
            return this._allowSkiping;
        }
        set allowSkipping(allowSkiping) {
            this._allowSkiping = allowSkiping;
        }
        get compressWhitespaces() {
            return this._compressWhitespaces;
        }
        set compressWhitespaces(compressWhitespaces) {
            this._compressWhitespaces = compressWhitespaces;
        }
    }
    Graphite.LexicalAnalyzerOptions = LexicalAnalyzerOptions;
})(Graphite || (Graphite = {}));
//# sourceMappingURL=LexicalAnalyzerOptions.js.map