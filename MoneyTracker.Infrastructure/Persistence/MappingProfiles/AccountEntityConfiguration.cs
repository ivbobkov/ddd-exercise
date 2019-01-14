using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence.MappingProfiles
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasKey(x => x.AccountId);
        }
    }
}
