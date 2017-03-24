using System.Text.RegularExpressions;

namespace Graphite.Implementations
{
    public class RegexTokenType : SkipableTokenType , ITokenType
    {
        private readonly Regex _regex;

        public RegexTokenType(string regex, bool skip = false) : base(skip)
        {
            _regex = new Regex(regex, RegexOptions.Singleline | RegexOptions.Compiled);            
        }

        public override bool Is(string word) =>
            _regex.IsMatch(word);
    }
}
