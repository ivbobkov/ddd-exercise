using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Infrastructure.Persistence.Entities;
using MoneyTracker.Infrastructure.Persistence.MappingProfiles;

namespace MoneyTracker.Infrastructure.Persistence
{
    public class MoneyTrackerDbContext : DbContext, IUnitOfWork
    {
        public MoneyTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IncomeEntityConfiguration());
        }

        public virtual DbSet<BalanceEntity> Balance { get; set; }
        public virtual DbSet<ExpenseEntity> Expenses { get; set; }
        public virtual DbSet<IncomeEntity> Incomes { get; set; }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
