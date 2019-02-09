using Microsoft.EntityFrameworkCore;
using MoneyTracker.Infrastructure.Persistence.Entities;
using MoneyTracker.Infrastructure.Persistence.MappingProfiles;

namespace MoneyTracker.Infrastructure.Persistence
{
    public class MoneyTrackerDbContext : DbContext
    {
        public MoneyTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SalaryEntityConfiguration());
        }

        public virtual DbSet<CurrencyEntity> Currencies { get; set; }
        public virtual DbSet<PurchaseEntity> Purchases { get; set; }
        public virtual DbSet<SalaryEntity> Salaries { get; set; }
    }
}
