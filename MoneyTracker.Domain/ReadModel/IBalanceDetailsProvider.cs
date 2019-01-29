using System;
using System.Threading.Tasks;

namespace MoneyTracker.Domain.ReadModel
{
    public interface IBalanceDetailsProvider
    {
        Task<BalanceDetailsDto> GetBalanceAsync(int balanceId);
    }
}