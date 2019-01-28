using System;
using System.Threading.Tasks;

namespace MoneyTracker.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
