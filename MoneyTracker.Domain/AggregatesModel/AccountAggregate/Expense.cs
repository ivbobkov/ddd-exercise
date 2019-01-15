using System;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.AggregatesModel.AccountAggregate
{
    public class Expense : IEntity<string>
    {
        public Expense(string id, Money value, DateTime spentAt, ExpenseType expenseType)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Amount <= 0)
            {
                throw new ArgumentException("Amount is less or equal to zero", nameof(value.Amount));
            }

            Id = id;
            Value = value;
            SpentAt = spentAt;
            ExpenseType = expenseType ?? throw new ArgumentNullException(nameof(expenseType));
        }

        public string Id { get; }
        public Money Value { get; }
        public DateTime SpentAt { get; }
        public ExpenseType ExpenseType { get; }
    }
}
