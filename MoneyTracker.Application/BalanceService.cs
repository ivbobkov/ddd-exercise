using System;
using System.Threading.Tasks;
using MoneyTracker.Domain;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;

namespace MoneyTracker.Application
{
    public class BalanceService : IBalanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBalanceRepository _balanceRepository;
        private readonly IProvideBalanceDetails _provideBalanceDetails;

        public BalanceService(IUnitOfWork unitOfWork, IBalanceRepository balanceRepository,
            IProvideBalanceDetails provideBalanceDetails)
        {
            _unitOfWork = unitOfWork;
            _balanceRepository = balanceRepository;
            _provideBalanceDetails = provideBalanceDetails;
        }

        public async Task AddPurchaseAsync(Money expense, DateTime spentAt)
        {
            var balance = await _balanceRepository.GetBalanceAsync();
            balance.AddPurchase(expense, spentAt);
            await _balanceRepository.UpdateAsync(balance);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddSalaryAsync(Money salary, DateTime receivedAt)
        {
            var balance = await _balanceRepository.GetBalanceAsync();
            balance.AddSalary(salary, receivedAt);
            await _balanceRepository.UpdateAsync(balance);
            await _unitOfWork.CommitAsync();
        }

        public async Task<BalanceDetailsDto> GetActualBalanceAsync()
        {
            return await _provideBalanceDetails.GetBalanceDetailsAsync();
        }
    }
}