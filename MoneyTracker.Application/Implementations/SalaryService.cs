using System;
using System.Threading.Tasks;
using MoneyTracker.Domain;
using MoneyTracker.Domain.WriteModel.SalaryAggregate;

namespace MoneyTracker.Application.Implementations
{
    public class SalaryService : ISalaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(IUnitOfWork unitOfWork, ISalaryRepository salaryRepository)
        {
            _unitOfWork = unitOfWork;
            _salaryRepository = salaryRepository;
        }

        public async Task AddSalaryAsync(decimal amount, string currency, DateTime receivedAt)
        {
            var salary = Salary.Create(amount, currency, receivedAt);
            _salaryRepository.Add(salary);
            await _unitOfWork.CommitAsync();
        }
    }
}
