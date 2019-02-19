using System;
using System.Collections.Generic;
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

        public async Task<Purchase> FindAsync(Guid purchaseId)
        {
            return await _purchaseRepository.FindAsync(purchaseId);
        }

        public async Task AddAsync(string currency, DateTime spentAt, IReadOnlyList<PurchaseItem> items)
        {
            var purchase = Purchase.Create(currency, spentAt, items);
            _purchaseRepository.Add(purchase);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid purchaseId, string currency, DateTime spentAt, IReadOnlyList<PurchaseItem> items)
        {
            var purchase = await _purchaseRepository.FindAsync(purchaseId);
            purchase.UpdateCurrency(currency);
            purchase.UpdateSpentAt(spentAt);
            purchase.UpdateItems(items);

            await _purchaseRepository.UpdateAsync(purchase);
            await _unitOfWork.CommitAsync();
        }
    }
}
