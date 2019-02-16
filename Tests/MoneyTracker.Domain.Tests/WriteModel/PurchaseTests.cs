using System;
using FluentAssertions;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.WriteModel
{
    [TestFixture]
    public class PurchaseTests
    {
        [Test]
        public void AddItem_AddData_VerifyAmount()
        {
            var purchase = Purchase.Create("USD", DateTime.UtcNow);
            purchase.AddItem("Position one", 100, 0);
            purchase.AddItem("Position two", 150, 0);

            purchase.Total.Amount.Should().Be(250);
            purchase.Total.Currency.Should().Be("USD");

            purchase.Items.Should()
                .Contain(x => x.Title.Equals("Position one"))
                .And
                .Contain(x => x.Title.Equals("Position two"));
        }
    }
}