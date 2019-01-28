using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Domain.WriteModel
{
    public class AccountRepository : IBalanceRepository
    {
        public AccountRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        protected MoneyTrackerDbContext DbContext => (MoneyTrackerDbContext) UnitOfWork;

        public void Add(Balance balance)
        {
            var dbEntity = new BalanceEntity
            {
                Expenses = balance.Expenses.Select(x => new ExpenseEntity
                {
                    Amount = x.Value.Amount,
                    ExpenseType = x.ExpenseType.Key,
                    SpentAt = x.SpentAt
                }).ToList(),
                Incomes = balance.Incomes.Select(x => new IncomeEntity
                {
                    Amount = x.Value.Amount,
                    ReceivedAt = x.ReceivedAt
                }).ToList()
            };

            DbContext.Accounts.Add(dbEntity);
        }

        public void Update(Balance balance)
        {
            var dbEntry = DbContext.Accounts
                .Include(x => x.Expenses)
                .Include(x => x.Incomes)
                .Single();

            foreach (var expense in balance.Expenses)
            {
                var entry = dbEntry.Expenses.FirstOrDefault(x =>
                    x.SpentAt == expense.SpentAt
                    && x.Amount == expense.Value.Amount
                    && x.ExpenseType == expense.ExpenseType.Key);

                if (entry == null)
                {
                    dbEntry.Expenses.Add(new ExpenseEntity
                    {
                        BalanceId = balance.Id,
                        Amount = expense.Value.Amount,
                        ExpenseType = expense.ExpenseType.Key
                    });
                    continue;
                }

                entry.Amount = expense.Value.Amount;
                entry.ExpenseType = expense.ExpenseType.Key;
                entry.SpentAt = expense.SpentAt;
            }

            foreach (var income in balance.Incomes)
            {
                var entry = dbEntry.Incomes.FirstOrDefault(x =>
                    x.ReceivedAt == income.ReceivedAt
                    && x.Amount == income.Value.Amount);

                if (entry == null)
                {
                    dbEntry.Incomes.Add(new IncomeEntity
                    {
                        BalanceId = balance.Id,
                        Amount = income.Value.Amount,
                        ReceivedAt = income.ReceivedAt
                    });
                    continue;
                }

                entry.Amount = income.Value.Amount;
                entry.ReceivedAt = income.ReceivedAt;
            }
        }

        public Balance Single()
        {
            var account = DbContext.Accounts
                .Include(x => x.Expenses)
                .Include(x => x.Incomes)
                .Single();

            return new Balance(
                account.BalanceId,
                account.Expenses.Select(x => new Expense(new Money(x.Amount, Currency.Byn), x.SpentAt, ExpenseType.Purchase)),
                account.Incomes.Select(x => new Income(new Money(x.Amount, Currency.Byn), x.ReceivedAt))
            );
        }
    }
}