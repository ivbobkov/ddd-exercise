using System.Threading.Tasks;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public interface IBalanceRepository : IRepository<Balance>
    {
        void Add(Balance balance);
        Task UpdateAsync(Balance balance);
        Task<Balance> GetBalanceAsync();
    }
}
