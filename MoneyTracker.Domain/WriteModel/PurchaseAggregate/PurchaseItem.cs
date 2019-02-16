namespace MoneyTracker.Domain.WriteModel.PurchaseAggregate
{
    public class PurchaseItem
    {
        public PurchaseItem(string title, decimal amount, decimal discount)
        {
            Title = title;
            Amount = amount;
            Discount = discount;
        }

        public string Title { get; }
        public decimal Amount { get; }
        public decimal Discount { get; }
    }
}