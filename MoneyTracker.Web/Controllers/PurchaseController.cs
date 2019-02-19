using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Web.Infrastructure;
using MoneyTracker.Web.ViewModels.Purchase;

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
            var model = LoadModel() ?? PurchaseViewModel.Create();

            return View("InputForm", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PurchaseViewModel model)
        {
            var purchases = model.Purchases.Select(x => x.ToModel()).ToList();
            await _purchaseService.AddAsync(model.Currency, model.SpentAt, purchases);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid purchaseId)
        {
            var model = LoadModel();

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
            var purchases = model.Purchases.Select(x => x.ToModel()).ToList();
            await _purchaseService.UpdateAsync(model.PurchaseId, model.Currency, model.SpentAt, purchases);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RemoveItem(int index, [FromForm] PurchaseViewModel model)
        {
            model.Purchases.RemoveAt(index);
            SaveModel(model);

            return model.IsNew ? RedirectToAction("Create") : RedirectToAction("Update");
        }

        [HttpPost]
        public IActionResult AddItem([FromForm] PurchaseViewModel model)
        {
            model.Purchases.Add(new PurchaseItemViewModel());
            SaveModel(model);

            return model.IsNew ? RedirectToAction("Create") : RedirectToAction("Update");
        }

        private void SaveModel(PurchaseViewModel model)
        {
            TempData.Put("Model", model);
        }

        private PurchaseViewModel LoadModel()
        {
            return TempData.Get<PurchaseViewModel>("Model");
        }
    }
}
