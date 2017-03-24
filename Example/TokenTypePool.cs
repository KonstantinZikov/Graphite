using Graphite;
using Graphite.Implementations;
using System.Collections.Generic;

namespace Example
{
    class XmlTokenTypePool : ITokenTypePool
    {
        private List<ITokenType> fastTypes;
        private List<ILazyResolvingType> lazyTypes;
        private ITokenType _nextLine = new OneValueTokenType("\n",true);
        private ITokenType _whitespace = new RegexTokenType(@"^ \z",true);

        public ITokenType Class { get; set; } = new OneValueTokenType("class");
        public ITokenType Id { get; set; } = new OneValueTokenType("id");

        public ITokenType OpenAngleBracket { get; set; } = new OneValueTokenType("<");
        public ITokenType CloseAngleBracket { get; set; } = new OneValueTokenType(">");
        public ITokenType SpecOpenAngleBracket { get; set; } = new OneValueTokenType("<?");
        public ITokenType SpecCloseAngleBracket { get; set; } = new OneValueTokenType("?>");
        public ITokenType OpenAngleBracketWithSlash { get; set; } = new OneValueTokenType("</");
        public ITokenType CloseAngleBracketWithSlash { get; set; } = new OneValueTokenType("/>");
        public ITokenType EqualsSign { get; set; } = new OneValueTokenType("=");
        public ITokenType Value { get; set; } = new RegexTokenType(@"^"".*""\z");
        public ITokenType PartOfValue { get; set; } = new RegexTokenType(@"^""[^""]*\z");
        public ILazyResolvingType Identifier { get; set; }

        public XmlTokenTypePool()
        {
            Identifier = new LazyResolvingType(
                new RegexTokenType(@"^[a-zA-Z_]([a-zA-Z_]|\d)*(\.([a-zA-Z_]|\d)*)*\z"),
                new List<ITokenType>
                {
                    Class,
                    Id
                }
            );

            fastTypes = new List<ITokenType>
            {
                OpenAngleBracket,
                CloseAngleBracket,
                CloseAngleBracketWithSlash,
                OpenAngleBracketWithSlash,
                SpecOpenAngleBracket,
                SpecCloseAngleBracket,
                EqualsSign,
                Value,
                PartOfValue,
                _whitespace,
                NextLine               
            };

            lazyTypes = new List<ILazyResolvingType>
            {
                Identifier
            };
        }

        public ICollection<ITokenType> FastResolvingTypes
        {
            get{ return fastTypes; }
        }

        public ICollection<ILazyResolvingType> LazyResolvingTypes
        {
            get{ return lazyTypes; }
        }

        public ITokenType NextLine
        {
            get{ return _nextLine; }
        }
    }
}
