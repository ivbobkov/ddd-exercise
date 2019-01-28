using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence.MappingProfiles
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<BalanceEntity>
    {
        public void Configure(EntityTypeBuilder<BalanceEntity> builder)
        {
            builder.HasKey(x => x.BalanceId);
        }
    }
}
