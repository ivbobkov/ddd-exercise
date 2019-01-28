using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence.MappingProfiles
{
    public class ExpenseEntityConfiguration : IEntityTypeConfiguration<ExpenseEntity>
    {
        public void Configure(EntityTypeBuilder<ExpenseEntity> builder)
        {
            builder.HasKey(x => x.ExpenseId);
        }
    }
}