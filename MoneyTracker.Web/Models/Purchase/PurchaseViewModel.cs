using System;
using System.Collections.Generic;

namespace MoneyTracker.Web.Models.Purchase
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel()
        {
            SpentAt = DateTime.UtcNow;
        }

        public DateTime SpentAt { get; set; }
        public string Currency { get; set; }
        public List<PurchaseItemViewModel> Purchases { get; set; } = new List<PurchaseItemViewModel>();
    }
}