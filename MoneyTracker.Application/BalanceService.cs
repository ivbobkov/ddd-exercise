using System;
using System.Threading.Tasks;
using MoneyTracker.Domain;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;
using MoneyTracker.Domain.WriteModel.SalaryAggregate;

namespace MoneyTracker.Application
{
    public class BalanceService : IBalanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ISalaryRepository _salaryRepository;

        private readonly IProvideBalanceDetails _provideBalanceDetails;

        public BalanceService(IUnitOfWork unitOfWork,
            IPurchaseRepository purchaseRepository,
            ISalaryRepository salaryRepository,
            IProvideBalanceDetails provideBalanceDetails)
        {
            _unitOfWork = unitOfWork;
            _purchaseRepository = purchaseRepository;
            _salaryRepository = salaryRepository;
            _provideBalanceDetails = provideBalanceDetails;
        }

        public async Task AddPurchaseAsync(string title, decimal amount, string currency, DateTime spentAt)
        {
            var purchase = Purchase.Create(currency, spentAt);
            purchase.AddItem(title, amount);
            _purchaseRepository.Add(purchase);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddSalaryAsync(decimal amount, string currency, DateTime receivedAt)
        {
            var salary = Salary.Create(amount, currency, receivedAt);
            _salaryRepository.Add(salary);
            await _unitOfWork.CommitAsync();
        }

        public async Task<BalanceDetailsDto> GetActualBalanceAsync()
        {
            return await _provideBalanceDetails.GetBalanceDetailsAsync();
        }
    }
}