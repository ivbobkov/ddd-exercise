using System;
using System.Collections.Generic;

namespace MoneyTracker.Domain.ReadModel
{
    public class PurchaseDto
    {
        public Guid PurchaseId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime SpentAt { get; set; }
        public IEnumerable<PurchaseItemDto> Purchases { get; set; }
    }
}