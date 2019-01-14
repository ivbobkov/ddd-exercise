using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Aggregates.AccountAggregate;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Application
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task AddExpenseAsync(Guid accountId, Money value, DateTime spentAt, ExpenseType expenseType)
        {
            var account = accountRepository.GetById(accountId);
            account.AddExpense(new Expense(value, spentAt, expenseType));
            await accountRepository.UnitOfWork.CommitAsync();
        }

        public async Task AddIncomeAsync(Guid accountId, Money value, DateTime receivedAt)
        {
            var account = accountRepository.GetById(accountId);
            account.AddIncome(new Income(value, receivedAt));
            await accountRepository.UnitOfWork.CommitAsync();
        }
    }
}