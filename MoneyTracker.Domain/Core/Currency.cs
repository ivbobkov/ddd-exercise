namespace MoneyTracker.Domain.Core
{
    public class Currency
    {
        public string Iso2Code { get; }
        public decimal Rate { get; }

        public Currency(string iso2Code, decimal rate)
        {
            Iso2Code = iso2Code;
            Rate = rate;
        }

        public static Currency Usd => new Currency("USD", 1M);
        public static Currency Byn => new Currency("BYN", 2M);
    }
}
