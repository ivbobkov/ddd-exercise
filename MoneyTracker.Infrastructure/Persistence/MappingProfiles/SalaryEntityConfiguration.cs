using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence.MappingProfiles
{
    public class SalaryEntityConfiguration : IEntityTypeConfiguration<SalaryEntity>
    {
        public void Configure(EntityTypeBuilder<SalaryEntity> builder)
        {
            builder.HasKey(x => x.SalaryId);
            builder.HasOne(x => x.Currency).WithMany().HasForeignKey(x => x.CurrencyCode).IsRequired();
        }
    }
}