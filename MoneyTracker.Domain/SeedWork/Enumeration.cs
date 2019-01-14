namespace MoneyTracker.Domain.SeedWork
{
    public abstract class Enumeration<TKey, TValue>
    {
        public TKey Key { get; protected set; }
        public TValue Value { get; protected set; }

        protected Enumeration(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration<TKey, TValue>;

            if (otherValue == null)
                return false;

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Key.Equals(otherValue.Key);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public abstract class Enumeration<TKey> : Enumeration<TKey, string>
    {
        protected Enumeration(TKey key, string value) : base(key, value)
        {
        }
    }
}
