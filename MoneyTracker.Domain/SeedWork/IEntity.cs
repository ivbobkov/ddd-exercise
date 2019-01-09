namespace MoneyTracker.Domain.SeedWork
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }
    }
}
