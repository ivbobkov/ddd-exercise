using System;
using System.Linq;
using System.Threading.Tasks;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;

namespace MoneyTracker.Application
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository accountRepository;

        public BalanceService(IBalanceRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task AddExpenseAsync(Guid accountId,
            string id,
            Money value,
            DateTime spentAt,
            ExpenseType expenseType)
        {
            var account = accountRepository.GetById(accountId);
            //account.AddExpense(new Expense(id, value, spentAt, expenseType));
            await accountRepository.UnitOfWork.CommitAsync();
        }

        public async Task AddIncomeAsync(
            Guid accountId,
            Money value,
            DateTime receivedAt)
        {
            var account = accountRepository.GetById(accountId);
            //account.AddIncome(new Income(value, receivedAt));
            await accountRepository.UnitOfWork.CommitAsync();
        }

        public async Task<Guid> CreateAsync()
        {
            var accountNumber = Guid.NewGuid();
            var account = new Balance(accountNumber, Enumerable.Empty<Expense>(), Enumerable.Empty<Income>());

            accountRepository.Add(account);
            await accountRepository.UnitOfWork.CommitAsync();

            return accountNumber;
        }

        public Task<BalanceDetailsDto> GetActualBalanceAsync()
        {
            throw new NotImplementedException();
        }
    }
}