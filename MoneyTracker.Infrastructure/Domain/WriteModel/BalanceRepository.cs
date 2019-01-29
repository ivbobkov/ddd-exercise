using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Domain.WriteModel
{
    public class BalanceRepository : IBalanceRepository
    {
        public BalanceRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        protected MoneyTrackerDbContext DbContext => (MoneyTrackerDbContext)UnitOfWork;

        public void Add(Balance balance)
        {
            var dbEntity = new BalanceEntity
            {
                Expenses = balance.Expenses.Select(x => new ExpenseEntity
                {
                    Amount = x.Value.Amount,
                    CurrencyCode = x.Value.Currency.Code,
                    ExpenseType = x.ExpenseType.Key,
                    SpentAt = x.SpentAt
                }).ToList(),
                Incomes = balance.Incomes.Select(x => new IncomeEntity
                {
                    Amount = x.Value.Amount,
                    CurrencyCode = x.Value.Currency.Code,
                    ReceivedAt = x.ReceivedAt
                }).ToList()
            };

            DbContext.Balance.Add(dbEntity);
        }

        public Balance Get(int id)
        {
            var account = DbContext.Balance
                .Include(x => x.Expenses)
                .Include(x => x.Incomes)
                .Single();

            return new Balance(
                account.BalanceId,
                account.Expenses.Select(x => new Expense(
                    new Money(x.Amount, Currency.ByCode(x.CurrencyCode)),
                    x.SpentAt,
                    ExpenseType.Purchase)
                ),
                account.Incomes.Select(x =>new Income(
                    new Money(x.Amount, Currency.ByCode(x.CurrencyCode)),
                    x.ReceivedAt)
                )
            );
        }
    }
}