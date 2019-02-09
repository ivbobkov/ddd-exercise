using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Domain.ReadModel
{
    public class ProvideCurrency : IProvideCurrency
    {
        private readonly MoneyTrackerDbContext _dbContext;

        public ProvideCurrency(MoneyTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CurrencyDto FindByCode(string code)
        {
            return new CurrencyDto();
        }

        public async Task<IEnumerable<CurrencyDto>> AllAsync()
        {
            var currencies = await _dbContext.Currencies.ToListAsync();

            return currencies.Select(x => new CurrencyDto { Code = x.Code });
        }
    }
}