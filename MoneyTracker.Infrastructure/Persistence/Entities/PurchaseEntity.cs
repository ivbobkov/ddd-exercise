using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class PurchaseEntity
    {
        public int PurchaseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime SpentAt { get; set; }
        public string CurrencyCode { get; set; }

        public virtual CurrencyEntity Currency { get; set; }
    }
}
