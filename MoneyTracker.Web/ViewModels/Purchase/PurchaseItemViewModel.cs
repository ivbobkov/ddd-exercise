using System;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;

namespace MoneyTracker.Web.ViewModels.Purchase
{
    public class PurchaseItemViewModel
    {
        public Guid PurchaseItemId { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }

        public PurchaseItem ToModel()
        {
            return new PurchaseItem(PurchaseItemId, Title, Quantity, Amount, Discount);
        }

        public static PurchaseItemViewModel Create()
        {
            return new PurchaseItemViewModel
            {
                PurchaseItemId = Guid.NewGuid()
            };
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