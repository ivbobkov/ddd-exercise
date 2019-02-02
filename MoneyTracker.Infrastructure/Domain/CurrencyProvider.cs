using MoneyTracker.Domain.Core;

namespace MoneyTracker.Infrastructure.Domain
{
    public class CurrencyProvider : ICurrencyProvider
    {
        public Currency Provide(string code)
        {
            return new Currency(code, 0);
        }
    }
}