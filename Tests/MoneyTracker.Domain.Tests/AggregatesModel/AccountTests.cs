using System;
using FluentAssertions;
using MoneyTracker.Domain.AggregatesModel.AccountAggregate;
using MoneyTracker.Domain.Core;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.AggregatesModel
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void GetAmount_DifferentCurrencies_ValidAmount()
        {
            var account = Account.Create();
            account.AddExpense(new Money(100, Currency.Byn), DateTime.UtcNow, ExpenseType.Purchase);
            account.AddExpense(new Money(200, Currency.Usd), DateTime.UtcNow, ExpenseType.Purchase);
            account.AddIncome(new Money(400, Currency.Usd), DateTime.UtcNow);

            var resultCurrency = Currency.Usd;

            // act
            var amount = account.GetAmount(resultCurrency);

            // assert
            amount.Amount.Should().Be(150);
            //amount.Currency.Should().BeEquivalentTo(resultCurrency);
        }
    }
}