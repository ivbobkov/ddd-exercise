using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Application
{
    public interface IBalanceService : IApplicationService
    {
        Task AddPurchaseAsync(Money expense, DateTime spentAt);
        Task AddSalaryAsync(Money salary, DateTime receivedAt);
        Task<BalanceDetailsDto> GetActualBalanceAsync();
    }
}