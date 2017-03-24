using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphite
{
    public class LexicalAnalyzer
    {
        private readonly ITokenTypePool _types;
        private readonly LexicalAnalyzerOptions _options;

        public LexicalAnalyzer(ITokenTypePool typePool)
        {
            _types = typePool;
            _options = new LexicalAnalyzerOptions
            {
                AllowSkiping = true,
                CompressWhitespaces = true
            };
        }

        public LexicalAnalyzer(ITokenTypePool typePool, LexicalAnalyzerOptions options)
        {
            _types = typePool;
        }


        public List<Token> Analize(string code)
        {
            if (_options.CompressWhitespaces)
            {
                code = NormilizeLines(code);
                code = CompressWhitespaces(code);
            }
            
            var tokens = DivideToTokens(code);
            for (int i = 0; i < tokens.Count; i++)
            {
                ILazyResolvingType resolvingType = tokens[i].Type as ILazyResolvingType;
                if (resolvingType != null)
                {
                    ResolveIdentifier(tokens[i], resolvingType);
                }                    
            }
                
            return tokens;
        }

        private string NormilizeLines(string code)
            => code.Replace("\r\n", "\n");

        private string CompressWhitespaces(string code)
        {
            var result = new StringBuilder(code.Length);
            bool isWhitespace = false;
            bool isNextLine = false;
            for (int i = 0; i < code.Length; i++)
            {
                if (char.IsWhiteSpace(code[i]))
                {
                    if (code[i] == '\n')
                    {
                        isNextLine = true;
                    }
                    else
                    {
                        isWhitespace = true;
                    }                        
                }                    
                else
                {
                    if (isNextLine)
                    {
                        result.Append('\n');
                    }
                    else
                    {
                        if (isWhitespace)
                        {
                            result.Append(' ');
                        }                            
                    }
                    
                    result.Append(code[i]);
                    isWhitespace = isNextLine = false;
                }
            }

            return result.ToString();
        }

        private List<Token> DivideToTokens(string code)
        {
            var result = new List<Token>();
            var word = new StringBuilder();
            int position = 0;
            var types = _types.FastResolvingTypes.Concat(_types.LazyResolvingTypes);
            bool match = false;
            ITokenType lastType = null;
            int lineNumber = 1;
            while (position < code.Length)
            {
                word.Append(code[position]);
                match = false;
                foreach (var type in types)
                {
                    if (type.Is(word.ToString()))
                    {
                        lastType = type;
                        match = true;
                        break;
                    }
                }

                if (!match && lastType != null)
                {
                    if (!(lastType.Skip && _options.AllowSkiping))
                    {
                        result.Add(new Token
                        {
                            Type = lastType,
                            Value = word.Remove(word.Length - 1, 1).ToString(),
                            Line = lineNumber
                        });
                    }

                    if (lastType == _types.NextLine)
                    {
                        lineNumber++;
                    }

                    lastType = null;
                    word.Clear();
                }
                else
                {
                    position++;
                }
            }

            if (lastType == null)
            {
                string message = "";
                if (result.Count == 0)
                {
                    message = "Unknown token in code start position.";
                }
                else
                {
                    var token = result.Last();
                    message = $"Unknown token after element {token.Value} at line {token.Line}.";
                }

                throw new LexicalAnalyzerException(message);
            }

            if (!(lastType.Skip && _options.AllowSkiping))
            {
                result.Add(new Token
                {
                    Type = lastType,
                    Value = word.ToString(),
                    Line = lineNumber
                });
            }
                
            return result;
        }

        private void ResolveIdentifier(Token token, ILazyResolvingType resolvingType)
        {
            foreach (var type in resolvingType.LeafTypes)
            {
                if (type.Is(token.Value))
                {
                    token.Type = type;
                    return;
                }
            }
        }
    }
}