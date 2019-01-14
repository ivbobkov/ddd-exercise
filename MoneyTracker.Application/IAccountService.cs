using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Aggregates.AccountAggregate;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Application
{
    public interface IAccountService
    {
        Task AddExpenseAsync(Guid accountId, Money value, DateTime spentAt, ExpenseType expenseType);
        Task AddIncomeAsync(Guid accountId, Money value, DateTime receivedAt);
    }
}