using MoneyTracker.Domain.SeedWork;

namespace MoneyTracker.Domain.AggregatesModel.AccountAggregate
{
    public class ExpenseType : Enumeration<int>
    {
        /// <inheritdoc />
        public ExpenseType(int id, string value) : base(id, value)
        {
        }
    }
}
