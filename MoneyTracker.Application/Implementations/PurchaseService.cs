using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(string currency, DateTime spentAt, IEnumerable<PurchaseItem> items)
        {
            var purchase = Purchase.Create(currency, spentAt);

            foreach (var item in items)
            {
                purchase.AddItem(item.Title, item.Amount, item.Discount);
            }

            _purchaseRepository.Add(purchase);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Guid purchaseId, string currency, DateTime spentAt, IEnumerable<PurchaseItem> items)
        {
            var purchase = await _purchaseRepository.FindAsync(purchaseId);
            purchase.UpdateCurrency(currency);
            purchase.UpdateSpentAt(spentAt);

            foreach (var item in items)
            {
                if (purchase.Items.Any(x => x.Id == item.Id))
                {
                    purchase.UpdateItem(item.Id, item.Title, item.Amount, item.Discount);
                    continue;
                }

                purchase.AddItem(item.Title, item.Amount, item.Discount);
            }

            await _purchaseRepository.UpdateAsync(purchase);
            await _unitOfWork.CommitAsync();
        }
    }
}
