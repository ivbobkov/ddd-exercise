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
        public IActionResult AddPurchase()
        {
            var model = TempData.Get<PurchaseViewModel>("Model") ?? new PurchaseViewModel();

            return View("AddPurchase", model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PurchaseViewModel model)
        {
            var purchases = model.Purchases.Select(x => new PurchaseItem(x.Title, x.Amount));
            await _purchaseService.AddPurchaseAsync(model.Currency, model.SpentAt, purchases);
            return RedirectToAction("Index", "Balance");
        }

        [HttpPost]
        public IActionResult RemoveItem(int index, [FromForm] PurchaseViewModel model)
        {
            model.Purchases.RemoveAt(index);
            TempData.Put("Model", model);

            return RedirectToAction("AddPurchase");
        }

        [HttpPost]
        public IActionResult AddItem([FromForm] PurchaseViewModel model)
        {
            model.Purchases.Add(new PurchaseItemViewModel());
            TempData.Put("Model", model);

            return RedirectToAction("AddPurchase");
        }
    }
}
