using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public interface IBalanceRepository : IRepository<Balance>
    {
        void Add(Balance balance);
        Balance Get(int id);
    }
}
