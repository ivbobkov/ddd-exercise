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
                var account = _balanceRepository.Single();
                account.AddExpense(value, spentAt, expenseType);
                await uow.CommitAsync();
            }
        }

        public async Task AddIncomeAsync(
            Money value,
            DateTime receivedAt)
        {
            using (var uow = _balanceRepository.UnitOfWork)
            {
                var account = _balanceRepository.Single();
                account.AddIncome(value, receivedAt);
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
            return await _balanceDetailsProvider.GetActualBalanceAsync();
        }
    }
}