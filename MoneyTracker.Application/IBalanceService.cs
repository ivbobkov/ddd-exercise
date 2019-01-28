using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;

namespace MoneyTracker.Application
{
    public interface IBalanceService
    {
        Task AddExpenseAsync(Money value, DateTime spentAt, ExpenseType expenseType);
        Task AddIncomeAsync(Money value, DateTime receivedAt);
        Task CreateAsync();
        Task<BalanceDetailsDto> GetActualBalanceAsync();
    }
}