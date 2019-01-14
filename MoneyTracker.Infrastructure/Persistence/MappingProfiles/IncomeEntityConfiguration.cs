using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence.MappingProfiles
{
    public class IncomeEntityConfiguration : IEntityTypeConfiguration<IncomeEntity>
    {
        public void Configure(EntityTypeBuilder<IncomeEntity> builder)
        {
            builder.HasKey(x => new
            {
                x.Amount,
                x.ReceivedAt
            });
        }
    }
}