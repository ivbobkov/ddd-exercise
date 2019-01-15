using System;
using System.Collections.Generic;
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

        public void AddExpense(Expense expense)
        {
            expense = expense ?? throw new ArgumentNullException(nameof(expense));
            expenses.Add(expense);
        }

        public void AddIncome(Income income)
        {
            income = income ?? throw new ArgumentNullException(nameof(income));
            incomes.Add(income);
        }

        public IEnumerable<Expense> Expenses => expenses;
        public IEnumerable<Income> Incomes => incomes;
    }
}
