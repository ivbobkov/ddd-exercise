using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class ExpenseEntity
    {
        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime SpentAt { get; set; }
        public int ExpenseType { get; set; }
        public int BalanceId { get; set; }

        public virtual BalanceEntity Balance { get; set; }
    }
}
