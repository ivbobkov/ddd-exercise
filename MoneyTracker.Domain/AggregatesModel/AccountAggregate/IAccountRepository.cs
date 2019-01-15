using System;
using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.AggregatesModel.AccountAggregate
{
    public interface IAccountRepository : IRepository<Account>
    {
        void Add(Account account);
        void Update(Account account);
        Account GetById(Guid accountId);
    }
}
