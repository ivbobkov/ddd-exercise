namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        void Add(Purchase purchase);
    }
}
