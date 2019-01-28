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
        public void GetAmount_VerifyBalance()
        {
            var account = Balance.Create();

            account.AddExpense(new Money(100, Currency.Byn), DateTime.UtcNow, ExpenseType.Purchase);
            account.AddExpense(new Money(200, Currency.Usd), DateTime.UtcNow, ExpenseType.Purchase);
            account.AddIncome(new Money(400, Currency.Usd), DateTime.UtcNow);

            // act
            var result = account.GetAmount(Currency.Usd);

            result.Amount.Should().Be(150);
            result.Currency.Iso2Code.Should().Be(Currency.Usd.Iso2Code);
        }
    }
}