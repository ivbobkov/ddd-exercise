using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;

namespace MoneyTracker.Application
{
    public interface IBalanceService
    {
        Task AddExpenseAsync(Guid accountId, string id, Money value, DateTime spentAt, ExpenseType expenseType);
        Task AddIncomeAsync(Guid accountId, Money value, DateTime receivedAt);
        Task<Guid> CreateAsync();
        Task<BalanceDetailsDto> GetActualBalanceAsync();
    }
}