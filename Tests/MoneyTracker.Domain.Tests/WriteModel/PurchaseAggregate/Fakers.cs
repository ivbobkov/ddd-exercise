using System.Collections.Generic;
using Bogus;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;

namespace MoneyTracker.Domain.Tests.WriteModel.PurchaseAggregate
{
    public static class PurchaseItemFaker
    {
        private static readonly Faker Faker = new Faker();

        public static PurchaseItem Create()
        {
            var commerce = Faker.Commerce;
            var random = Faker.Random;

            var amount = random.Decimal(0.1M, 1000M);

            return PurchaseItem.Create(commerce.ProductName(), "45", amount, random.Decimal(0M, amount));
        }

        public static List<PurchaseItem> Generate(int count)
        {
            var result = new List<PurchaseItem>(count);

            for (var index = 0; index < count; index++)
            {
                result.Add(Create());
            }

            return result;
        }
    }

    public static class PurchaseFaker
    {
        private static readonly Faker Faker = new Faker();

        public static Purchase Any()
        {
            return Create(Faker.Random.Int(1, 10));
        }

        public static Purchase Create(int itemsCount)
        {
            var currency = Faker.Finance.Currency();

            return Purchase.Create(currency.Code, Faker.Date.Past(100), PurchaseItemFaker.Generate(itemsCount));
        }
    }
}