using System;

namespace MoneyTracker.Domain.ReadModel
{
    public class SalaryDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}