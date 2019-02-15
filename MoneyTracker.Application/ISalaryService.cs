using System;
using System.Threading.Tasks;

namespace MoneyTracker.Application
{
    public interface ISalaryService : IApplicationService
    {
        Task AddSalaryAsync(decimal amount, string currency, DateTime receivedAt);
    }
}
