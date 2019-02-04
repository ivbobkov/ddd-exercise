﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Domain.WriteModel
{
    public class BalanceRepository : IBalanceRepository
    {
        public BalanceRepository(MoneyTrackerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected MoneyTrackerDbContext DbContext { get; }
        protected DbSet<PurchaseEntity> Purchases => DbContext.Purchases;
        protected DbSet<SalaryEntity> Salaries => DbContext.Salaries;

        public void Add(Balance balance)
        {
            foreach (var purchase in balance.Purchases)
            {
                Purchases.Add(ProjectTo(purchase));
            }

            foreach (var salary in balance.Salaries)
            {
                Salaries.Add(ProjectTo(salary));
            }
        }

        public async Task UpdateAsync(Balance balance)
        {
            var purchases = await Purchases.ToListAsync();

            foreach (var purchase in balance.Purchases)
            {
                var dbEntry = purchases.FirstOrDefault(x => x.PurchaseId == purchase.Id);

                if (dbEntry != null)
                {
                    ProjectTo(purchase, dbEntry);
                    continue;
                }

                Purchases.Add(ProjectTo(purchase));
            }

            var salaries = await Salaries.ToListAsync();

            foreach (var salary in balance.Salaries)
            {
                var dbEntry = salaries.FirstOrDefault(x => x.SalaryId == salary.Id);

                if (dbEntry != null)
                {
                    ProjectTo(salary, dbEntry);
                    continue;
                }

                Salaries.Add(ProjectTo(salary));
            }
        }

        private Purchase Map(PurchaseEntity source)
        {
            return new Purchase(
                source.PurchaseId,
                new Money(source.Amount, source.CurrencyCode),
                source.ReceivedAt
            );
        }

        private Salary Map(SalaryEntity source)
        {
            return new Salary(
                source.SalaryId,
                new Money(source.Amount, source.CurrencyCode),
                source.SpentAt
            );
        }

        private static PurchaseEntity ProjectTo(Purchase source, PurchaseEntity destination)
        {
            destination.Amount = source.Value.Amount;
            destination.CurrencyCode = source.Value.Currency;
            destination.ReceivedAt = source.SpentAt;
            return destination;
        }

        private static PurchaseEntity ProjectTo(Purchase source)
        {
            return new PurchaseEntity
            {
                Amount = source.Value.Amount,
                CurrencyCode = source.Value.Currency,
                ReceivedAt = source.SpentAt
            };
        }

        private static SalaryEntity ProjectTo(Salary source, SalaryEntity destination)
        {
            destination.Amount = source.Value.Amount;
            destination.CurrencyCode = source.Value.Currency;
            destination.SpentAt = source.ReceivedAt;
            return destination;
        }

        private static SalaryEntity ProjectTo(Salary source)
        {
            return new SalaryEntity
            {
                Amount = source.Value.Amount,
                CurrencyCode = source.Value.Currency,
                SpentAt = source.ReceivedAt
            };
        }

        public async Task<Balance> GetBalanceAsync()
        {
            var purchases = await Purchases.ToListAsync();
            var salaries = await Salaries.ToListAsync();
            return new Balance(purchases.Select(Map), salaries.Select(Map));
        }
    }
}