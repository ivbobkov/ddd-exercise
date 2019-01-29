using System;
using System.Threading.Tasks;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;

namespace MoneyTracker.Application
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceDetailsProvider _balanceDetailsProvider;
        private readonly IBalanceRepository _balanceRepository;

        public BalanceService(IBalanceDetailsProvider balanceDetailsProvider, IBalanceRepository balanceRepository)
        {
            _balanceDetailsProvider = balanceDetailsProvider;
            _balanceRepository = balanceRepository;
        }

        public async Task AddExpenseAsync(
            Money value,
            DateTime spentAt,
            ExpenseType expenseType)
        {
            using (var uow = _balanceRepository.UnitOfWork)
            {
                var balance = _balanceRepository.Get(1);
                balance.AddExpense(value, spentAt, expenseType);
                await uow.CommitAsync();
            }
        }

        public async Task AddIncomeAsync(
            Money value,
            DateTime receivedAt)
        {
            using (var uow = _balanceRepository.UnitOfWork)
            {
                var balance = _balanceRepository.Get(1);
                balance.AddIncome(value, receivedAt);
                await uow.CommitAsync();
            }
        }

        public async Task CreateAsync()
        {
            using (var uow = _balanceRepository.UnitOfWork)
            {
                var account = Balance.Create();
                _balanceRepository.Add(account);
                await uow.CommitAsync();
            }
        }

        public async Task<BalanceDetailsDto> GetActualBalanceAsync()
        {
            return await _balanceDetailsProvider.GetBalanceAsync(1);
        }
    }
}