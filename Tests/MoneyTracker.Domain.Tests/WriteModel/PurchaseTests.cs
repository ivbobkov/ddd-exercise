using System;
using System.Collections.Generic;
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
            var purchaseItems = new List<PurchaseItem>
            {
                PurchaseItem.Create("Position one", 100, 0),
                PurchaseItem.Create("Position two", 150, 0),
                PurchaseItem.Create("Position three", 10, 7)
            };

            var purchase = Purchase.Create("USD", DateTime.UtcNow, purchaseItems);

            purchase.Total.Amount.Should().Be(253);
            purchase.Total.Currency.Should().Be("USD");

            purchase.Items.Should().HaveCount(purchase.Items.Count());
        }

        [Test]
        public void Update_ValidData_VerifyChangedData()
        {
            var initialPurchaseItems = new List<PurchaseItem>
            {
                PurchaseItem.Create("1", 100, 0),
                PurchaseItem.Create("2", 150, 0),
                PurchaseItem.Create("3", 10, 7)
            };

            var purchase = Purchase.Create("USD", DateTime.UtcNow, initialPurchaseItems);

            var newPurchaseItems = new List<PurchaseItem>
            {
                initialPurchaseItems[0],
                new PurchaseItem(initialPurchaseItems[1].Id, "New 2", 100, 15),
                PurchaseItem.Create("4", 75, 0)
            };

            // act
            purchase.UpdateItems(newPurchaseItems);

            // assert
            purchase.Items.Should().HaveCount(3);
            purchase.Items[0].Should().BeEquivalentTo(initialPurchaseItems[0]);

            purchase.Items[1].Id.Should().Be(initialPurchaseItems[1].Id);
            purchase.Items[1].Title.Should().BeEquivalentTo("New 2");
            purchase.Items[1].Amount.Should().Be(100);
            purchase.Items[1].Discount.Should().Be(15);

            purchase.Items[2].Id.Should().Be(newPurchaseItems[2].Id);
            purchase.Items[2].Title.Should().BeEquivalentTo("4");
            purchase.Items[2].Amount.Should().Be(75);
            purchase.Items[2].Discount.Should().Be(0);
        }
    }
}