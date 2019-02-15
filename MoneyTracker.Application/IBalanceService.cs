using System.Threading.Tasks;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Application
{
    public interface IBalanceService : IApplicationService
    {
        Task<BalanceDetailsDto> GetActualBalanceAsync();
    }
}