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

        public void Add(Purchase purchase)
        {
            var purchaseEntity = new PurchaseEntity
            {
                PurchaseId = purchase.Id,
                Amount = purchase.Total.Amount,
                CurrencyCode = purchase.Total.Currency,
                SpentAt = purchase.SpentAt
            };

            foreach (var purchaseItem in purchase.Items)
            {
                purchaseEntity.Items.Add(new PurchaseItemEntity
                {
                    Title = purchaseItem.Title,
                    Amount = purchaseItem.Amount
                });
            }

            Purchases.Add(purchaseEntity);
        }
    }
}