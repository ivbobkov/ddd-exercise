using System;
using System.Collections.Generic;
using System.Linq;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public class Balance : IEntity<int>, IAggregateRoot
    {
        private readonly List<Expense> _expenses = new List<Expense>(0);
        private readonly List<Income> _incomes = new List<Income>(0);

        public Balance(int id, IEnumerable<Expense> expenses, IEnumerable<Income> incomes)
        {
            Id = id;
            _expenses.AddRange(expenses);
            _incomes.AddRange(incomes);
        }

        public int Id { get; }
        public IEnumerable<Expense> Expenses => _expenses;
        public IEnumerable<Income> Incomes => _incomes;

        public void AddExpense(Money value, DateTime spentAt, ExpenseType expenseType)
        {
            _expenses.Add(new Expense(value, spentAt, expenseType));
        }

        public void AddIncome(Money value, DateTime receivedAt)
        {
            _incomes.Add(new Income(value, receivedAt));
        }

        public Money GetAmount(Currency currency)
        {
            var totalExpenses = _expenses.Sum(x => x.Value.Convert(Currency.Usd).Amount);
            var totalIncomes = _incomes.Sum(x => x.Value.Convert(Currency.Usd).Amount);
            var total = (totalIncomes - totalExpenses) * currency.Rate;
            return new Money(total, currency);
        }

        public static Balance Create()
        {
            return new Balance(0, Enumerable.Empty<Expense>(), Enumerable.Empty<Income>());
        }
    }
}
