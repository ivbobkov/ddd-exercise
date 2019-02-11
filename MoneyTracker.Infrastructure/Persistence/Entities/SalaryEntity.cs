using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class SalaryEntity
    {
        public Guid SalaryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ReceivedAt { get; set; }
        public string CurrencyCode { get; set; }

        public virtual CurrencyEntity Currency { get; set; }
    }
}