using System;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public class Salary : IEntity<int>
    {
        protected Salary()
        {
        }

        public Salary(int id, Money value, DateTime receivedAt)
        {
            Id = id;
            Value = value;
            ReceivedAt = receivedAt;
        }

        public int Id { get; }
        public Money Value { get; }
        public DateTime ReceivedAt { get; }

        public static Salary Create(Money value, DateTime spentAt)
        {
            return new Salary(0, value, spentAt);
        }
    }
}
