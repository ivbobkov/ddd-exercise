namespace MoneyTracker.Domain.WriteModel.SalaryAggregate
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        void Add(Salary salary);
    }
}
