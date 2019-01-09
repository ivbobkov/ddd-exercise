namespace MoneyTracker.Domain.SeedWork
{
    public abstract class Enumeration<TId>
    {
        public TId Id { get; protected set; }
        public string Value { get; protected set; }

        protected Enumeration(TId id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}
