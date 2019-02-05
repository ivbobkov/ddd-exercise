using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Domain.ReadModel
{
    public class ProvideBalanceDetails : IProvideBalanceDetails
    {
        private readonly MoneyTrackerDbContext _dbContext;

        public ProvideBalanceDetails(MoneyTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BalanceDetailsDto> GetBalanceDetailsAsync()
        {
            var purchases = await _dbContext.Purchases.ToListAsync();
            var salaries = await _dbContext.Salaries.ToListAsync();

            return new BalanceDetailsDto
            {
                Salaries = salaries.Select(x => new SalaryDto
                {
                    Amount = x.Amount,
                    Currency = x.CurrencyCode,
                    ReceivedAt = x.ReceivedAt
                }),
                Purchases = purchases.Select(x => new PurchaseDto
                {
                    Amount = x.Amount,
                    Currency = x.CurrencyCode,
                    SpentAt = x.SpentAt
                })
            };
        }
    }
}