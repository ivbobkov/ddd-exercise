using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.WriteModel.PurchaseAggregate
{
    [TestFixture]
    public class PurchaseTests
    {
        [Test]
        public void AddItem_NewData_VerifyAmount()
        {
            var purchaseItems = PurchaseItemFaker.Generate(3);
            var amount = purchaseItems.Sum(x => x.Amount - x.Discount);

            var purchase = Purchase.Create("USD", DateTime.UtcNow, purchaseItems);

            purchase.Total.Amount.Should().Be(amount);
            purchase.Total.Currency.Should().Be("USD");

            purchase.Items.Should().HaveCount(purchase.Items.Count());
        }

        [Test]
        public void UpdateItems_ValidData_VerifyChangedData()
        {
            var purchase = PurchaseFaker.Create(3);
            var initialPurchaseItems = purchase.Items.ToList();
            var newPurchaseItems = new List<PurchaseItem>
            {
                new PurchaseItem(initialPurchaseItems[1].Id, "New 2", 100, 15),
                PurchaseItemFaker.Create(),
                PurchaseItemFaker.Create(),
                initialPurchaseItems[0],
            };

            // act
            purchase.UpdateItems(newPurchaseItems);

            // assert
            purchase.Items.OrderBy(x => x.Id).Should().HaveCount(newPurchaseItems.Count)
                .And.Equal(newPurchaseItems.OrderBy(x => x.Id), (a, b) =>
                    a.Id == b.Id
                    && a.Title == b.Title
                    && a.Amount == b.Amount
                    && a.Discount == b.Discount);
        }
    }
}