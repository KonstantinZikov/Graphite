using System;
using Graphite;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = DateTime.Now;
            var pool = new XmlTokenTypePool();
            var options = new LexicalAnalyzerOptions
            {
                AllowSkiping = true,
                CompressWhitespaces = true
            };
            var analyzer = new LexicalAnalyzer(pool);

            string code;
            using(var reader = new StreamReader("./xmlforparsing.xml"))
            {
                code = reader.ReadToEnd();
            }

            var results = analyzer.Analize(code);
            foreach(var token in results)
            {
                Console.WriteLine($"VALUE:{token.Value} LINE:{token.Line};");
            }
            Console.WriteLine(DateTime.Now - a);
            Console.ReadKey();
        }
    }
}
