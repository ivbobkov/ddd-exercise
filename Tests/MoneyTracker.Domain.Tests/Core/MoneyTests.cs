using FluentAssertions;
using MoneyTracker.Domain.Core;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.Core
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void Convert()
        {
            var byn = new Currency("BYN", 2);
            var usd = new Currency("USD", 1);

            var amount = new Money(100, byn);

            var newAmount = amount.Convert(usd);
            newAmount.Amount.Should().Be(50);
        }
    }
}