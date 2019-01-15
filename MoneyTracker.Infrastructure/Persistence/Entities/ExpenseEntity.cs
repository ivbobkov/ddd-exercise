using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class ExpenseEntity
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }
        public DateTime SpentAt { get; set; }
        public int ExpenseType { get; set; }
        public Guid AccountId { get; set; }

        public AccountEntity Account { get; set; }
    }
}
