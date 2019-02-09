using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyTracker.Domain.ReadModel
{
    public interface IProvideCurrency
    {
        Task<IEnumerable<CurrencyDto>> AllAsync();
    }
}