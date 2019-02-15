using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;

namespace MoneyTracker.Application
{
    public interface IPurchaseService : IApplicationService
    {
        Task AddPurchaseAsync(string currency, DateTime spentAt, IEnumerable<PurchaseItem> purchaseItems);
    }
}
