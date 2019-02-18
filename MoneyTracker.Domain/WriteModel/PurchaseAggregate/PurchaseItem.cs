using System;

namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public class PurchaseItem : IEntity<Guid>
    {
        public PurchaseItem(Guid id, string title, decimal amount, decimal discount)
        {
            Id = id;
            Title = title;
            Amount = amount;
            Discount = discount;
        }

        public Guid Id { get; internal set; }
        public string Title { get; internal set; }
        public decimal Amount { get; internal set; }
        public decimal Discount { get; internal set; }

        public static PurchaseItem Create(string title, decimal amount, decimal discount)
        {
            return new PurchaseItem(Guid.NewGuid(), title, amount, discount);
        }
    }
}