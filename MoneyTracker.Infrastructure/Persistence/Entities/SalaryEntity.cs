using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class SalaryEntity
    {
        public int SalaryId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime SpentAt { get; set; }
    }
}