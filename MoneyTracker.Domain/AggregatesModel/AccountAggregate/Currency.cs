using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.AggregatesModel.AccountAggregate
{
    public class Currency : Enumeration<int>
    {
        public decimal Rate { get; private set; }

        public Currency(int id, string value, decimal rate) : base(id, value)
        {
            Rate = rate;
        }
    }
}
