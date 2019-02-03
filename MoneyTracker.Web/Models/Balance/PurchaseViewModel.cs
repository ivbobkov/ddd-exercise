using System;

namespace MoneyTracker.Web.Models.Balance
{
    public class PurchaseViewModel
    {
        public MoneyViewModel Purchase { get; set; }
        public DateTime SpentAt { get; set; }
    }
}