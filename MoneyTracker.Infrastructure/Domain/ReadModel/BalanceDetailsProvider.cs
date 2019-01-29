using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<BalanceDetailsDto> GetBalanceAsync(int balanceId)
        {
            var balance = await _dbContext.Balance
                .Include(x => x.Expenses)
                .Include(x => x.Incomes)
                .FirstOrDefaultAsync(x => x.BalanceId == balanceId);

            return new BalanceDetailsDto
            {
                ActualAmount = new Money(100, Currency.Byn)
            };
        }
    }
}