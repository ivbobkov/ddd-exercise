using System.Collections.Generic;

namespace MoneyTracker.Domain.ReadModel
{
    public interface IProvideCurrency
    {
        CurrencyDto FindByCode(string code);
        IEnumerable<CurrencyDto> FindAll();
    }
}