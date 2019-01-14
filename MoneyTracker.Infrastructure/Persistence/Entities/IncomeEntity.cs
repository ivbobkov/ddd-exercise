using System;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class IncomeEntity
    {
        public decimal Amount { get; set; }
        public DateTime ReceivedAt { get; set; }
        public Guid AccountId { get; set; }

        public AccountEntity Account { get; set; }
    }
}