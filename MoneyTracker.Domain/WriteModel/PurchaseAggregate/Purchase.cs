using System;
using System.Collections.Generic;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public class Purchase : IAggregateRoot, IEntity<Guid>
    {
        private readonly List<PurchaseItem> _items = new List<PurchaseItem>();

        public Purchase(Guid id, string currency, DateTime spentAt)
        {
            Id = id;
            Total = Money.Empty(currency);
            SpentAt = spentAt;
        }

        public Guid Id { get; }
        public Money Total { get; protected set; }
        public DateTime SpentAt { get; }
        public IEnumerable<PurchaseItem> Items => _items;

        public void AddItem(string title, decimal amount, decimal discount)
        {
            Total = Total.Sum(amount).Min(discount);
            _items.Add(new PurchaseItem(title, amount, discount));
        }

        public static Purchase Create(string currency, DateTime spentAt)
        {
            return new Purchase(Guid.NewGuid(), currency, spentAt);
        }
    }
}
