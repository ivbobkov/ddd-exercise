using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyTracker.Domain.QueriesModel
{
    public interface IAccountProvider
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
    }
}