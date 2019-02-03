using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public class Purchase : IEntity<int>
    {
        public Purchase(int id, Money value, DateTime spentAt)
        {
            Value = value;
            SpentAt = spentAt;
            Id = id;
        }

        public int Id { get; }
        public Money Value { get; }
        public DateTime SpentAt { get; }

        public static Purchase Create(Money value, DateTime spentAt)
        {
            return new Purchase(0, value, spentAt);
        }
    }
}
