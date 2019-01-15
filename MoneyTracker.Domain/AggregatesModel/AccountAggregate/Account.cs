using System;
using System.Collections.Generic;
using System.Linq;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.AggregatesModel.AccountAggregate
{
    public class Account : IEntity<Guid>, IAggregateRoot
    {
        private readonly List<Expense> expenses = new List<Expense>(0);
        private readonly List<Income> incomes = new List<Income>(0);

        public Account(Guid accountId, IEnumerable<Expense> expenses, IEnumerable<Income> incomes)
        {
            Id = accountId;
            this.expenses.AddRange(expenses);
            this.incomes.AddRange(incomes);
        }

        public Guid Id { get; }

        public IEnumerable<Expense> Expenses => expenses;
        public IEnumerable<Income> Incomes => incomes;

        public void AddExpense(Money value, DateTime spentAt, ExpenseType expenseType)
        {
            expenses.Add(new Expense(value, spentAt, expenseType));
        }

        public void AddIncome(Money value, DateTime receivedAt)
        {
            incomes.Add(new Income(value, receivedAt));
        }

        public Money GetAmount(Currency currency)
        {
            var totalExpenses = expenses.Sum(x => x.Value.Convert(Currency.Usd).Amount);
            var totalIncomes = incomes.Sum(x => x.Value.Convert(Currency.Usd).Amount);
            var total = (totalIncomes - totalExpenses) * currency.Rate;
            return new Money(total, currency);
        }

        public static Account Create()
        {
            var id = Guid.NewGuid();
            return new Account(id, Enumerable.Empty<Expense>(), Enumerable.Empty<Income>());
        }
    }
}
