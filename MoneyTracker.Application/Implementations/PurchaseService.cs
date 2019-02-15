using System;
using System.Threading.Tasks;
using MoneyTracker.Domain;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;

namespace MoneyTracker.Application.Implementations
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository)
        {
            _unitOfWork = unitOfWork;
            _purchaseRepository = purchaseRepository;
        }

        public async Task AddPurchaseAsync(string title, decimal amount, string currency, DateTime spentAt)
        {
            var purchase = Purchase.Create(currency, spentAt);
            purchase.AddItem(title, amount);
            _purchaseRepository.Add(purchase);
            await _unitOfWork.CommitAsync();
        }
    }
}
