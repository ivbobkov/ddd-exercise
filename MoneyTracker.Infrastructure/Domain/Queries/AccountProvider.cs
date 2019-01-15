using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyTracker.Domain.QueriesModel;
using MoneyTracker.Infrastructure.Persistence;

namespace MoneyTracker.Infrastructure.Domain.Queries
{
    public class AccountProvider : IAccountProvider
    {
        private readonly MoneyTrackerDbContext dbContext;

        public AccountProvider(MoneyTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            return await dbContext.Accounts
                .Select(x => new AccountDto
                {
                    AccountNumber = x.AccountId
                })
                .ToListAsync();
        }
    }
}
