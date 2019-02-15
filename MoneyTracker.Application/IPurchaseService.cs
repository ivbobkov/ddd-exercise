using System;
using System.Threading.Tasks;

namespace MoneyTracker.Application
{
    public interface IPurchaseService : IApplicationService
    {
        Task AddPurchaseAsync(string title, decimal amount, string currency, DateTime spentAt);
    }
}
