using System;

namespace MoneyTracker.Domain.ReadModel
{
    public class PurchaseItemDto
    {
        public Guid PurchaseItemId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
    }
}