using System;

namespace MoneyTracker.Domain.ReadModel
{
    public class PurchaseDto
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime SpentAt { get; set; }
    }
}