using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.SalaryAggregate
{
    public class Salary : IAggregateRoot, IEntity<Guid>
    {
        public Salary(Guid id, Money total, DateTime receivedAt)
        {
            Id = id;
            Total = total;
            ReceivedAt = receivedAt;
        }

        public Guid Id { get; }
        public Money Total { get; }
        public DateTime ReceivedAt { get; }

        public static Salary Create(decimal amount, string currency, DateTime spentAt)
        {
            return new Salary(Guid.NewGuid(), new Money(amount, currency), spentAt);
        }
    }
}
