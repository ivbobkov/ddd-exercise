namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public class PurchaseItem
    {
        public PurchaseItem(string title, decimal amount)
        {
            Title = title;
            Amount = amount;
        }

        public string Title { get; }
        public decimal Amount { get; }
    }
}