using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Application
{
    public interface IBalanceService : IApplicationService
    {
        Task AddPurchaseAsync(string title, decimal amount, string currency, DateTime spentAt);
        Task AddSalaryAsync(decimal amount, string currency, DateTime receivedAt);
        Task<BalanceDetailsDto> GetActualBalanceAsync();
    }
}