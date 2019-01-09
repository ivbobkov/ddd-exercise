using System.Threading.Tasks;

namespace MoneyTracker.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task ComminAsync();
    }
}
