using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MoneyTracker.Web.Infrastructure;

namespace MoneyTracker.Web.Models.Purchase
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel()
        {
            SpentAt = DateTime.UtcNow;
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = ViewConstants.DefaultDateTimeFormatString)]
        public DateTime SpentAt { get; set; }
        public string Currency { get; set; }
        public List<PurchaseItemViewModel> Purchases { get; set; } = new List<PurchaseItemViewModel>();
    }
}