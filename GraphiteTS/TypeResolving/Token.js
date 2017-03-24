var Graphite;
(function (Graphite) {
    /**
     * Main class which contains information about separated code part.
     */
    class Token {
        get type() { return this._type; }
        set type(type) { this.type = type; }
        get value() { return this._value; }
        set value(value) { this.value = value; }
        get line() { return this._line; }
        set line(line) { this._line = line; }
    }
    Graphite.Token = Token;
})(Graphite || (Graphite = {}));
//# sourceMappingURL=Token.js.map