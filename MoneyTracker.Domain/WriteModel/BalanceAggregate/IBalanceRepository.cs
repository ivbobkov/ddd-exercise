using System.Threading.Tasks;
using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public interface IBalanceRepository : IRepository<Balance>
    {
        void Add(Balance balance);
        Task UpdateAsync(Balance balance);
        Task<Balance> GetBalanceAsync();
    }
}
