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
        protected DbSet<PurchaseEntity> Salaries => DbContext.Set<PurchaseEntity>();

        public void Add(Purchase balance)
        {
            throw new System.NotImplementedException();
        }
    }
}