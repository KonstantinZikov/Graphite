var Extensions;
(function (Extensions_1) {
    class Extensions {
        static run() {
            this.stringExtensions();
        }
        static stringExtensions() {
            String.prototype["IsWhiteSpace"] = function () {
                /[\f\n\r\t\v\u00A0\u2028\u2029]/.test(this);
            };
        }
    }
    Extensions_1.Extensions = Extensions;
})(Extensions || (Extensions = {}));
//# sourceMappingURL=Extensions.js.map