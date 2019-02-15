using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Web.Models.Balance;

namespace MoneyTracker.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IProvideCurrency _provideCurrency;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IProvideCurrency provideCurrency, IPurchaseService purchaseService)
        {
            _provideCurrency = provideCurrency;
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> AddPurchase()
        {
            var currencies = await _provideCurrency.AllAsync();
            var viewModel = new PurchaseViewModel().SetCurrencies(currencies);

            return View("AddPurchase", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPurchase(PurchaseViewModel model)
        {
            await _purchaseService.AddPurchaseAsync(model.Title, model.Purchase.Amount, model.Purchase.Currency, model.SpentAt);
            return RedirectToAction("Index", "Balance");
        }
    }
}
