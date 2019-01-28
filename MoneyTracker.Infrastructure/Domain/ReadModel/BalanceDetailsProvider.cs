using System.Threading.Tasks;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Infrastructure.Domain.ReadModel
{
    public class BalanceDetailsProvider : IBalanceDetailsProvider
    {
        public async Task<BalanceDetailsDto> GetActualBalanceAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}