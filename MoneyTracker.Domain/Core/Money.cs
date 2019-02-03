using System;

namespace MoneyTracker.Domain.Core
{
    public class Money : IEquatable<Money>
    {
        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; }
        public string Currency { get; }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && string.Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
            }
        }
    }
}