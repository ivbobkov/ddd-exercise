using System;
using System.Threading.Tasks;

namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<Purchase> FindAsync(Guid purchaseId);
        Task DeleteAsync(Guid purchaseId);
        void Add(Purchase purchase);
        Task UpdateAsync(Purchase purchase);
    }
}
