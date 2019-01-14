using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.Aggregates.AccountAggregate
{
    public class Income
    {
        public Income(Money value, DateTime receivedAt)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Amount <= 0)
            {
                throw new ArgumentException("Argument <= 0", nameof(value.Amount));
            }

            Value = value;
            ReceivedAt = receivedAt;
        }

        public Money Value { get; }
        public DateTime ReceivedAt { get; }
    }
}
