using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.Aggregates.AccountAggregate
{
    public class ExpenseType : Enumeration<int>
    {
        public bool HasDetails { get; }

        /// <inheritdoc />
        public ExpenseType(int key, string value, bool hasDetails) : base(key, value)
        {
            HasDetails = hasDetails;
        }

        public static ExpenseType Purchase => new ExpenseType(1, "Purchase", true);
    }
}
