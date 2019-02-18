using System;
using System.Collections.Generic;
using System.Linq;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public class Purchase : IAggregateRoot, IEntity<Guid>
    {
        private readonly List<PurchaseItem> _items = new List<PurchaseItem>();
        private string _currency;

        public Purchase(Guid id, string currency, DateTime spentAt)
        {
            Id = id;
            _currency = currency;
            SpentAt = spentAt;
        }

        public Guid Id { get; }

        public Money Total
        {
            get
            {
                var total = Items.Sum(x => x.Amount - x.Discount);
                return new Money(total, _currency);
            }
        }

        public DateTime SpentAt { get; protected set; }
        public IEnumerable<PurchaseItem> Items => _items;

        public void UpdateSpentAt(DateTime spentAt)
        {
            SpentAt = spentAt;
        }

        public void UpdateCurrency(string currency)
        {
            _currency = currency;
        }

        public void AddItem(string title, decimal amount, decimal discount)
        {
            _items.Add(PurchaseItem.Create(title, amount, discount));
        }

        public void UpdateItem(Guid itemId, string title, decimal amount, decimal discount)
        {
            var entry = _items.FirstOrDefault(x => x.Id == itemId);

            if (entry == null)
            {
                throw new ArgumentException("No item added by given id", nameof(itemId));
            }

            entry.Title = title;
            entry.Amount = amount;
            entry.Discount = discount;
        }

        public static Purchase Create(string currency, DateTime spentAt)
        {
            return new Purchase(Guid.NewGuid(), currency, spentAt);
        }
    }
}
