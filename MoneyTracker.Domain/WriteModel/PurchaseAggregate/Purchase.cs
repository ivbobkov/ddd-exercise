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

        public Purchase(Guid id, string currency, DateTime spentAt, IEnumerable<PurchaseItem> items)
        {
            var itemsToSave = items.ToList();

            if (!itemsToSave.Any())
            {
                throw new ArgumentException("Expected at least one");
            }

            Id = id;
            _currency = currency;
            SpentAt = spentAt;
            _items = itemsToSave;
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

        public void UpdateItems(IEnumerable<PurchaseItem> items)
        {
            var itemsToUpdate = items.ToList();

            if (!itemsToUpdate.Any())
            {
                throw new ArgumentException();
            }

            foreach (var item in itemsToUpdate)
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

            _items.RemoveAll(item => itemsToUpdate.All(x => x.Id != item.Id));
        }

        public static Purchase Create(string currency, DateTime spentAt, IEnumerable<PurchaseItem> items)
        {
            return new Purchase(Guid.NewGuid(), currency, spentAt, items);
        }
    }
}
