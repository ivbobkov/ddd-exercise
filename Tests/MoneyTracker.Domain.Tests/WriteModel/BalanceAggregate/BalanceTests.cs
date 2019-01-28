using System;
using FluentAssertions;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.WriteModel.BalanceAggregate
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void GetAmount_DifferentCurrencies_ValidAmount()
        {
            var account = Balance.Create();
            account.AddExpense(new Money(100, Currency.Byn), DateTime.UtcNow, ExpenseType.Purchase);
            account.AddExpense(new Money(200, Currency.Usd), DateTime.UtcNow, ExpenseType.Purchase);
            account.AddIncome(new Money(400, Currency.Usd), DateTime.UtcNow);

            // act
            var amount = account.GetAmount(Currency.Usd);

            // assert
            amount.Amount.Should().Be(150);
        }
    }
}