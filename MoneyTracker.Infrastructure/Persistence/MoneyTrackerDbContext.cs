using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.SeedWork;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence
{
    public class MoneyTrackerDbContext : DbContext, IUnitOfWork
    {
        public virtual DbSet<AccountEntity> Accounts { get; set; }
        public virtual DbSet<ExpenseEntity> Expenses { get; set; }
        public virtual DbSet<IncomeEntity> Incomes { get; set; }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
