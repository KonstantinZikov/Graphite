using System;

namespace Graphite.Implementations
{
    public class OneValueTokenType : SkipableTokenType, ITokenType
    {
        private readonly string _value;

        public OneValueTokenType(string value, bool skip = false) : base(skip)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{ nameof(value) } is null.");
            }

            _value = value;
        }

        public override bool Is(string word) => _value == word;

    }
}