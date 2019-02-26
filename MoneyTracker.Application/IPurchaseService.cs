using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;

namespace MoneyTracker.Application
{
    public interface IPurchaseService : IApplicationService
    {
        Task<Purchase> FindAsync(Guid purchaseId);
        Task DeleteAsync(Guid purchaseId);
        Task CreateAsync(string currency, DateTime spentAt, IReadOnlyList<PurchaseItem> items);
        Task UpdateAsync(Guid purchaseId, string currency, DateTime spentAt, IReadOnlyList<PurchaseItem> items);
    }
}
