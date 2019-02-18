using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.WriteModel.PurchaseAggregate;
using MoneyTracker.Web.Infrastructure;
using MoneyTracker.Web.Models.Purchase;

namespace MoneyTracker.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = TempData.Get<PurchaseViewModel>("Model");
            model = model ?? PurchaseViewModel.CreateNew();

            return View("InputForm", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PurchaseViewModel model)
        {
            var purchases = model.Purchases.Select(x => new PurchaseItem(x.PurchaseItemId, x.Title, x.Amount, x.Discount));

            await _purchaseService.AddAsync(model.Currency, model.SpentAt, purchases);
            return RedirectToAction("Index", "Balance");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid purchaseId)
        {
            var model = TempData.Get<PurchaseViewModel>("Model");

            if (model == null)
            {
                var purchase = await _purchaseService.FindAsync(purchaseId);
                model = PurchaseViewModel.From(purchase);
            }

            return View("InputForm", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] PurchaseViewModel model)
        {
            var purchases = model.Purchases.Select(x => new PurchaseItem(x.PurchaseItemId, x.Title, x.Amount, x.Discount));

            await _purchaseService.UpdateAsync(model.PurchaseId, model.Currency, model.SpentAt, purchases);
            return RedirectToAction("Index", "Balance");
        }

        [HttpPost]
        public IActionResult RemoveItem(int index, [FromForm] PurchaseViewModel model)
        {
            model.Purchases.RemoveAt(index);
            TempData.Put("Model", model);

            return model.IsNew
                ? RedirectToAction("Create")
                : RedirectToAction("Update");
        }

        [HttpPost]
        public IActionResult AddItem([FromForm] PurchaseViewModel model)
        {
            model.Purchases.Add(new PurchaseItemViewModel());
            TempData.Put("Model", model);

            return model.IsNew
                ? RedirectToAction("Create")
                : RedirectToAction("Update");
        }
    }
}
