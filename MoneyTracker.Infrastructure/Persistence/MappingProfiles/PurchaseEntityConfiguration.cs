using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence.MappingProfiles
{
    public class PurchaseEntityConfiguration : IEntityTypeConfiguration<PurchaseEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseEntity> builder)
        {
            builder.HasKey(x => x.PurchaseId);
            builder.HasOne(x => x.Currency).WithMany().HasForeignKey(x => x.CurrencyCode).IsRequired();
        }
    }
}