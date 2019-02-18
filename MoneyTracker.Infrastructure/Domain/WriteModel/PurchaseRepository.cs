using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Domain.WriteModel
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public PurchaseRepository(MoneyTrackerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected MoneyTrackerDbContext DbContext { get; }
        protected DbSet<PurchaseEntity> Purchases => DbContext.Set<PurchaseEntity>();

        public async Task<Purchase> FindAsync(Guid purchaseId)
        {
            var dbEntity = await Purchases.Include(x => x.Items).SingleAsync(x => x.PurchaseId == purchaseId);
            var purchase = new Purchase(dbEntity.PurchaseId, dbEntity.CurrencyCode, dbEntity.SpentAt);

            foreach (var item in dbEntity.Items)
            {
                purchase.AddItem(item.Title, item.Amount, item.Discount);
            }

            return purchase;
        }

        public void Add(Purchase purchase)
        {
            var dbEntity = new PurchaseEntity
            {
                PurchaseId = purchase.Id,
                Amount = purchase.Total.Amount,
                CurrencyCode = purchase.Total.Currency,
                SpentAt = purchase.SpentAt
            };

            foreach (var purchaseItem in purchase.Items)
            {
                dbEntity.Items.Add(new PurchaseItemEntity
                {
                    Title = purchaseItem.Title,
                    Amount = purchaseItem.Amount,
                    Discount = purchaseItem.Discount
                });
            }

            Purchases.Add(dbEntity);
        }

        public async Task UpdateAsync(Purchase purchase)
        {
            var dbEntity = await Purchases
                .Include(x => x.Items)
                .SingleAsync(x => x.PurchaseId == purchase.Id);

            dbEntity.Amount = purchase.Total.Amount;
            dbEntity.CurrencyCode = purchase.Total.Currency;
            dbEntity.SpentAt = purchase.SpentAt;

            foreach (var purchaseItem in dbEntity.Items)
            {
                var entry = dbEntity.Items.FirstOrDefault(x => x.PurchaseItemId == purchaseItem.PurchaseItemId);

                if (entry == null)
                {
                    dbEntity.Items.Add(new PurchaseItemEntity
                    {
                        Title = purchaseItem.Title,
                        Amount = purchaseItem.Amount,
                        Discount = purchaseItem.Discount
                    });
                    continue;
                }

                entry.Title = purchaseItem.Title;
                entry.Amount = purchaseItem.Amount;
                entry.Discount = purchaseItem.Discount;
            }
        }
    }
}