using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<CurrencyDto> FindAll()
        {
            var currencies = _dbContext.Currencies.ToList();

            return currencies.Select(x => new CurrencyDto { Code = x.Code });
        }
    }
}