using System;

namespace MoneyTracker.Domain.Core
{
    public class Money
    {
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public decimal Amount { get; }
        public Currency Currency { get; }
    }
}