using System;
using System.Collections.Generic;

namespace MoneyTracker.Infrastructure.Persistence.Entities
{
    public class AccountEntity
    {
        public Guid AccountId { get; set; }

        public virtual ICollection<ExpenseEntity> Expenses { get; set; } = new List<ExpenseEntity>(0);
        public virtual ICollection<IncomeEntity> Incomes { get; set; } = new List<IncomeEntity>(0);
    }
}
