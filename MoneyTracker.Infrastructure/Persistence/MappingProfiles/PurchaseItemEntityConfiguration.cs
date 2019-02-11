﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTracker.Infrastructure.Persistence.Entities;

namespace MoneyTracker.Infrastructure.Persistence.MappingProfiles
{
    public class PurchaseItemEntityConfiguration : IEntityTypeConfiguration<PurchaseItemEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseItemEntity> builder)
        {
            builder.HasKey(x => new { x.PurchaseId, x.Title, x.Amount });

            builder.HasOne(x => x.Purchase).WithMany(x => x.Items).IsRequired();
        }
    }
}