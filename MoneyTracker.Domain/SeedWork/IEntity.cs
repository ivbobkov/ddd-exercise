namespace MoneyTracker.Domain.SeedWork
{
    public interface IEntity<out TId>
    {
        TId Id { get; }
    }
}
