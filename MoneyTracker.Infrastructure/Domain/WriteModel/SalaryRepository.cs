using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.WriteModel.SalaryAggregate;
using MoneyTracker.Infrastructure.Persistence;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Domain.WriteModel
{
    public class SalaryRepository : ISalaryRepository
    {
        public SalaryRepository(MoneyTrackerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected MoneyTrackerDbContext DbContext { get; }
        protected DbSet<SalaryEntity> Salaries => DbContext.Set<SalaryEntity>();

        public void Add(Salary salary)
        {
            throw new System.NotImplementedException();
        }
    }
}