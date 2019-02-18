using System;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;

namespace MoneyTracker.Web.Models.Purchase
{
    public class PurchaseItemViewModel
    {
        public Guid PurchaseItemId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

        public static PurchaseItemViewModel Create()
        {
            return new PurchaseItemViewModel();
        }

        public static PurchaseItemViewModel From(PurchaseItem item)
        {
            return new PurchaseItemViewModel
            {
                PurchaseItemId = item.Id,
                Title = item.Title,
                Amount = item.Amount,
                Discount = item.Discount
            };
        } 
    }
}