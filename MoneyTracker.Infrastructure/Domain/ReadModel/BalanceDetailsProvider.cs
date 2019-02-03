using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Domain.ReadModel
{
    public class BalanceDetailsProvider : IBalanceDetailsProvider
    {
        private readonly MoneyTrackerDbContext _dbContext;

        public BalanceDetailsProvider(MoneyTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BalanceDetailsDto> GetBalanceDetailsAsync()
        {
            return new BalanceDetailsDto
            {
                ActualAmount = new Money(100, "")
            };
        }
    }
}