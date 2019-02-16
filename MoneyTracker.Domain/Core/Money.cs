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

        public Money Sum(decimal amount)
        {
            return new Money(Amount + amount, Currency);
        }

        public Money Min(decimal amount)
        {
            return new Money(Amount - amount, Currency);
        }

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
            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode() ^ Currency.GetHashCode();
        }

        public static Money Empty(string currency)
        {
            return new Money(0, currency);
        }
    }
}