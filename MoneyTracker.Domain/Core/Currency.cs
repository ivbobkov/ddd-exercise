namespace MoneyTracker.Domain.Core
{
    public class Currency
    {
        public Currency(string code, decimal rate)
        {
            Code = code;
            Rate = rate;
        }

        public string Code { get; }

        public decimal Rate { get; }
    }
}
