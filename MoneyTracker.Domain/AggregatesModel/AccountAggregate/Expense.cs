using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.AggregatesModel.AccountAggregate
{
    public class Expense
    {
        public Expense(Money value, DateTime spentAt, ExpenseType expenseType)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Amount <= 0)
            {
                throw new ArgumentException("Amount is less or equal to zero", nameof(value.Amount));
            }

            Value = value;
            SpentAt = spentAt;
            ExpenseType = expenseType ?? throw new ArgumentNullException(nameof(expenseType));
        }

        public Money Value { get; }
        public DateTime SpentAt { get; }
        public ExpenseType ExpenseType { get; }
    }
}
