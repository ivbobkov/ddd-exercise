namespace MoneyTracker.Domain.Core
{
    public interface ICurrencyProvider
    {
        Currency Provide(string code);
    }
}