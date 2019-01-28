using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class IncomeEntity
    {
        public int IncomeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ReceivedAt { get; set; }
        public int BalanceId { get; set; }

        public virtual BalanceEntity Balance { get; set; }
    }
}