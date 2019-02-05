using System;
using System.Collections.Generic;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Domain.WriteModel.BalanceAggregate
{
    public class Balance : IAggregateRoot
    {
        private readonly List<Purchase> _purchases = new List<Purchase>();
        private readonly List<Salary> _salaries = new List<Salary>();

        public Balance(IEnumerable<Purchase> purchases, IEnumerable<Salary> salaries)
        {
            _purchases.AddRange(purchases);
            _salaries.AddRange(salaries);
        }

        public IEnumerable<Purchase> Purchases => _purchases;
        public IEnumerable<Salary> Salaries => _salaries;

        public void AddPurchase(Money expense, DateTime spentAt)
        {
            _purchases.Add(Purchase.Create(expense, spentAt));
        }

        public void AddSalary(Money income, DateTime receivedAt)
        {
            _salaries.Add(Salary.Create(income, receivedAt));
        }
    }
}
