using System.Threading.Tasks;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Application.Implementations
{
    public class BalanceService : IBalanceService
    {
        private readonly IProvideBalanceDetails _provideBalanceDetails;

        public BalanceService(IProvideBalanceDetails provideBalanceDetails)
        {
            _provideBalanceDetails = provideBalanceDetails;
        }

        public async Task<BalanceDetailsDto> GetActualBalanceAsync()
        {
            return await _provideBalanceDetails.GetBalanceDetailsAsync();
        }
    }
}