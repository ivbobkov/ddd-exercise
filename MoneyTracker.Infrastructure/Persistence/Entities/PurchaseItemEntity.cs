using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class PurchaseItemEntity
    {
        public Guid PurchaseItemId { get; set; }

        public Guid PurchaseId { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

        public virtual PurchaseEntity Purchase { get; set; }
    }
}