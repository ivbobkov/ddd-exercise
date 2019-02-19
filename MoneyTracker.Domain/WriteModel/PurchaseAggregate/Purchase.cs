using System;
using System.Collections.Generic;
using System.Linq;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public class Purchase : IAggregateRoot, IEntity<Guid>
    {
        private string _currency;
        private readonly List<PurchaseItem> _items;

        public Purchase(Guid id, string currency, DateTime spentAt, IReadOnlyList<PurchaseItem> items)
        {
            if (!items.Any())
            {
                throw new ArgumentException("Expected at least one");
            }

            Id = id;
            _currency = currency;
            SpentAt = spentAt;
            _items = items.ToList();
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
        public IReadOnlyList<PurchaseItem> Items => _items;

        public void UpdateSpentAt(DateTime spentAt)
        {
            SpentAt = spentAt;
        }

        public void UpdateCurrency(string currency)
        {
            _currency = currency;
        }

        public void UpdateItems(IReadOnlyList<PurchaseItem> items)
        {
            if (items.Count < 1)
            {
                throw new ArgumentException();
            }

            foreach (var item in items)
            {
                var itemToUpdate = _items.SingleOrDefault(x => x.Id == item.Id);

                if (itemToUpdate != null)
                {
                    itemToUpdate.Title = item.Title;
                    itemToUpdate.Amount = item.Amount;
                    itemToUpdate.Discount = item.Discount;
                    continue;
                }

                _items.Add(item);
            }

            _items.RemoveAll(item => items.All(x => x.Id != item.Id));
        }

        public static Purchase Create(string currency, DateTime spentAt, IReadOnlyList<PurchaseItem> items)
        {
            return new Purchase(Guid.NewGuid(), currency, spentAt, items);
        }
    }
}
