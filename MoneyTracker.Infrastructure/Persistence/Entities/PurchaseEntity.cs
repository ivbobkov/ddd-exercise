using System;
using System.Collections.Generic;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class PurchaseEntity
    {
        public Guid PurchaseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime SpentAt { get; set; }
        public string CurrencyCode { get; set; }

        public virtual CurrencyEntity Currency { get; set; }
        public virtual ICollection<PurchaseItemEntity> Items { get; set; } = new List<PurchaseItemEntity>();
    }
}
