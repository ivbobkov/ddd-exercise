using System;
using System.Linq;
using FluentAssertions;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.WriteModel
{
    [TestFixture]
    public class PurchaseTests
    {
        [Test]
        public void AddItem_NewData_VerifyAmount()
        {
            var purchase = Purchase.Create("USD", DateTime.UtcNow);
            purchase.AddItem("Position one", 100, 0);
            purchase.AddItem("Position two", 150, 0);
            purchase.AddItem("Position three", 10, 7);

            purchase.Total.Amount.Should().Be(253);
            purchase.Total.Currency.Should().Be("USD");

            purchase.Items.Should().HaveCount(purchase.Items.Count());
        }

        [Test]
        public void UpdateItem_UpdateData_VerifyAmount()
        {
            const string initialName = "One";
            const string currencyCode = "USD";
            const decimal initialAmount = 100;
            const decimal initialDiscount = 48;

            var purchase = Purchase.Create(currencyCode, DateTime.UtcNow);
            purchase.AddItem(initialName, initialAmount, initialDiscount);
            var itemId = purchase.Items.Single().Id;

            // act
            purchase.UpdateItem(itemId, "Two", 150, 13);

            // assert
            purchase.Total.Amount.Should().Be(137);
            purchase.Total.Currency.Should().Be(currencyCode);
            purchase.Items.Should().Contain(x => x.Id == itemId && x.Amount == 150 && x.Discount == 13);
        }
    }
}