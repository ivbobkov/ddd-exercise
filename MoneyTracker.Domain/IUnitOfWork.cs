using System;
using System.Threading.Tasks;

namespace MoneyTracker.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
