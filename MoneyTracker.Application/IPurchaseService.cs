using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;

namespace MoneyTracker.Application
{
    public interface IPurchaseService : IApplicationService
    {
        Task<Purchase> FindAsync(Guid purchaseId);
        Task AddAsync(string currency, DateTime spentAt, IEnumerable<PurchaseItem> items);
        Task UpdateAsync(Guid purchaseId, string currency, DateTime spentAt, IEnumerable<PurchaseItem> items);
    }
}
