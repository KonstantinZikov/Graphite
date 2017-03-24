namespace Graphite.Implementations
{
    public abstract class SkipableTokenType : ITokenType
    {
        private readonly bool _skip;

        public bool Skip { get { return _skip; } }

        public SkipableTokenType(bool skip)
        {
            _skip = skip;
        }

        public abstract bool Is(string word);
    }
}
