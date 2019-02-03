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
        private readonly IBalanceDetailsProvider _balanceDetailsProvider;

        public BalanceService(IUnitOfWork unitOfWork, IBalanceRepository balanceRepository,
            IBalanceDetailsProvider balanceDetailsProvider)
        {
            _unitOfWork = unitOfWork;
            _balanceRepository = balanceRepository;
            _balanceDetailsProvider = balanceDetailsProvider;
        }

        public async Task AddPurchaseAsync(Money expense, DateTime spentAt)
        {
            var balance = await _balanceRepository.GetBalanceAsync();
            balance.AddPurchase(expense, spentAt);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddSalaryAsync(Money salary, DateTime receivedAt)
        {
            var balance = await _balanceRepository.GetBalanceAsync();
            balance.AddSalary(salary, receivedAt);
            await _unitOfWork.CommitAsync();
        }

        public async Task<BalanceDetailsDto> GetActualBalanceAsync()
        {
            return await _balanceDetailsProvider.GetBalanceDetailsAsync();
        }
    }
}