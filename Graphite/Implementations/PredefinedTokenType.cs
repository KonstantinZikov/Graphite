using System;
using System.Collections.Generic;

namespace Graphite.Implementations
{
    public class PredefinedTokenType : SkipableTokenType ,ITokenType
    {
        private readonly IEnumerable<string> _validValues;

        public PredefinedTokenType(IEnumerable<string> validValues, bool skip = false) : base(skip)
        {
            if (validValues == null)
            {
                throw new ArgumentNullException($"{ nameof(validValues) } is null.");
            }
                
            _validValues = validValues;
        }

        public override bool Is(string word)
        {
            foreach (var value in _validValues)
            {
                if (Equals(value, word))
                {
                    return true;
                }                 
            }
                
            return false;
        }
    }
}