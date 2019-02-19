using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using PurchaseModel = MoneyTracker.Domain.WriteModel.PurchaseAggregate.Purchase;

namespace MoneyTracker.Web.ViewModels.Purchase
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel()
        {
            SpentAt = DateTime.UtcNow;
        }

        public Guid PurchaseId { get; set; }
        public bool IsNew { get; set; }
        public DateTime SpentAt { get; set; }
        public string Currency { get; set; }

        public List<PurchaseItemViewModel> Purchases { get; set; } = new List<PurchaseItemViewModel>();

        public static PurchaseViewModel Create()
        {
            return new PurchaseViewModel
            {
                IsNew = true,
                SpentAt = DateTime.UtcNow
            };
        }

        public static PurchaseViewModel From(PurchaseModel purchase)
        {
            return new PurchaseViewModel
            {
                IsNew = false,
                PurchaseId = purchase.Id,
                Currency = purchase.Total.Currency,
                SpentAt = purchase.SpentAt,
                Purchases = purchase.Items.Select(PurchaseItemViewModel.From).ToList()
            };
        }
    }
}