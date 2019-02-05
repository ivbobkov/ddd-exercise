using System.Threading.Tasks;

namespace MoneyTracker.Domain.ReadModel
{
    public interface IProvideBalanceDetails
    {
        Task<BalanceDetailsDto> GetBalanceDetailsAsync();
    }
}