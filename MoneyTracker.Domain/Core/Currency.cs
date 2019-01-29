using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTracker.Domain.Core
{
    public class Currency
    {
        public string Code { get; }
        public decimal Rate { get; }

        public Currency(string code, decimal rate)
        {
            Code = code;
            Rate = rate;
        }

        public static Currency ByCode(string code)
        {
            return All().Single(x => x.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Currency> All()
        {
            yield return Usd;
            yield return Byn;
        }

        public static Currency Usd => new Currency("USD", 1M);
        public static Currency Byn => new Currency("BYN", 2M);
    }
}
