using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class PurchaseEntity
    {
        public int PurchaseId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
