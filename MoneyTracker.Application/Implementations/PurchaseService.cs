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

        public async Task AddPurchaseAsync(string currency, DateTime spentAt, IEnumerable<PurchaseItem> purchaseItems)
        {
            var purchase = Purchase.Create(currency, spentAt);
            foreach (var purchaseItem in purchaseItems)
            {
                purchase.AddItem(purchaseItem.Title, purchaseItem.Amount);
            }

            _purchaseRepository.Add(purchase);
            await _unitOfWork.CommitAsync();
        }
    }
}
