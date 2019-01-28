using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public class Expense
    {
        public Expense(Money value, DateTime spentAt, ExpenseType expenseType)
        {
            Value = value;
            SpentAt = spentAt;
            ExpenseType = expenseType ?? throw new ArgumentNullException(nameof(expenseType));
        }

        public Money Value { get; }
        public DateTime SpentAt { get; }
        public ExpenseType ExpenseType { get; }
    }
}
