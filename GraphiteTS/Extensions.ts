namespace Extensions {
    export class Extensions {
        public static run() {
            this.stringExtensions();
        }   

        private static stringExtensions(){
            String.prototype["IsWhiteSpace"] = function () {
                /[\f\n\r\t\v\u00A0\u2028\u2029]/.test(this);
            }
        }  
    }
}

