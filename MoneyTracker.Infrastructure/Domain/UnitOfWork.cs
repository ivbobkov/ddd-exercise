using System.Threading.Tasks;
using MoneyTracker.Domain;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoneyTrackerDbContext _dbContext;

        public UnitOfWork(MoneyTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}