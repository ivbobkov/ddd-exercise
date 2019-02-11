using System;
using FluentAssertions;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.WriteModel.SalaryAggregate;
using NUnit.Framework;

namespace MoneyTracker.Domain.Tests.WriteModel
{
    [TestFixture]
    public class SalaryTests
    {
        [Test]
        public void Create_VerifyData()
        {
            var utcNow = DateTime.UtcNow;
            var money = new Money(1000, "USD");

            var salary = Salary.Create(1000, "USD", utcNow);

            salary.Total.Should().BeEquivalentTo(money);
            salary.ReceivedAt.Should().Be(utcNow);
        }
    }
}