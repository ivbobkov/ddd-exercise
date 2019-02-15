using System;
using System.Collections.Generic;

namespace MoneyTracker.Domain.ReadModel
{
    public class PurchaseDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime SpentAt { get; set; }
        public IEnumerable<PurchaseItemDto> Purchases { get; set; }
    }
}