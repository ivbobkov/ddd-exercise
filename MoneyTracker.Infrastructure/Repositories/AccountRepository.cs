using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.AggregatesModel.AccountAggregate;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        protected MoneyTrackerDbContext DbContext => (MoneyTrackerDbContext) UnitOfWork;

        public void Add(Account account)
        {
            var dbEntity = new AccountEntity
            {
                AccountId = account.Id,
                Expenses = account.Expenses.Select(x => new ExpenseEntity
                {
                    AccountId = account.Id,
                    Amount = x.Value.Amount,
                    ExpenseType = x.ExpenseType.Key,
                    SpentAt = x.SpentAt
                }).ToList(),
                Incomes = account.Incomes.Select(x => new IncomeEntity
                {
                    AccountId = account.Id,
                    Amount = x.Value.Amount,
                    ReceivedAt = x.ReceivedAt
                }).ToList()
            };

            DbContext.Accounts.Add(dbEntity);
        }

        public void Update(Account account)
        {
            var dbEntry = DbContext.Accounts
                .Include(x => x.Expenses)
                .Include(x => x.Incomes)
                .Single(x => x.AccountId == account.Id);

            foreach (var expense in account.Expenses)
            {
                var entry = dbEntry.Expenses.FirstOrDefault(x =>
                    x.SpentAt == expense.SpentAt
                    && x.Amount == expense.Value.Amount
                    && x.ExpenseType == expense.ExpenseType.Key);

                if (entry == null)
                {
                    dbEntry.Expenses.Add(new ExpenseEntity
                    {
                        AccountId = account.Id,
                        Amount = expense.Value.Amount,
                        ExpenseType = expense.ExpenseType.Key
                    });
                    continue;
                }

                entry.Amount = expense.Value.Amount;
                entry.ExpenseType = expense.ExpenseType.Key;
                entry.SpentAt = expense.SpentAt;
            }

            foreach (var income in account.Incomes)
            {
                var entry = dbEntry.Incomes.FirstOrDefault(x =>
                    x.ReceivedAt == income.ReceivedAt
                    && x.Amount == income.Value.Amount);

                if (entry == null)
                {
                    dbEntry.Incomes.Add(new IncomeEntity
                    {
                        AccountId = account.Id,
                        Amount = income.Value.Amount,
                        ReceivedAt = income.ReceivedAt
                    });
                    continue;
                }

                entry.Amount = income.Value.Amount;
                entry.ReceivedAt = income.ReceivedAt;
            }
        }

        public Account GetById(Guid accountId)
        {
            var account = DbContext.Accounts
                .Include(x => x.Expenses)
                .Include(x => x.Incomes)
                .Single(x => x.AccountId == accountId);

            return new Account(
                account.AccountId,
                account.Expenses.Select(x => new Expense(new Money(x.Amount, Currency.Byn), x.SpentAt, ExpenseType.Purchase)),
                account.Incomes.Select(x => new Income(new Money(x.Amount, Currency.Byn), x.ReceivedAt))
            );
        }
    }
}