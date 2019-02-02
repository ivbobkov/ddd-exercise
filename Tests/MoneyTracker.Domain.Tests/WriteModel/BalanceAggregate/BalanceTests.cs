using System;
using System.Linq;
using FluentAssertions;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.WriteModel.BalanceAggregate
{
    [TestFixture]
    public class BalanceTests
    {
        [Test]
        public void AddPurchase_VerifyAdded()
        {
            var income = new Money(100, new Currency("USD", 1));
            var spentAt = DateTime.UtcNow;

            var balance = CreateEmpty();
            balance.AddPurchase(income, spentAt);

            balance.Purchases.Should().Contain(x => x.SpentAt.Equals(spentAt) && x.Value.Equals(income));
        }

        [Test]
        public void AddSalary_VerifyAdded()
        {
            var income = new Money(100, new Currency("USD", 1));
            var receivedAt = DateTime.UtcNow;

            var balance = CreateEmpty();
            balance.AddSalary(income, receivedAt);

            balance.Salaries.Should().Contain(x => x.ReceivedAt.Equals(receivedAt) && x.Value.Equals(income));
        }

        private static Balance CreateEmpty()
        {
            return new Balance(Enumerable.Empty<Purchase>(), Enumerable.Empty<Salary>());
        }
    }
}