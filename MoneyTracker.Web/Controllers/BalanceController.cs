using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Web.Models.Balance;

namespace MoneyTracker.Web.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IBalanceService _balanceService;
        private readonly IProvideCurrency _provideCurrency;

        public BalanceController(IBalanceService balanceService, IProvideCurrency provideCurrency)
        {
            _balanceService = balanceService;
            _provideCurrency = provideCurrency;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accounts = await _balanceService.GetActualBalanceAsync();
            return View(accounts);
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
            await _balanceService.AddPurchaseAsync(model.Title, model.Purchase.Amount, model.Purchase.Currency, model.SpentAt);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddSalary()
        {
            var currencies = await _provideCurrency.AllAsync();
            var viewModel = new SalaryViewModel().SetCurrencies(currencies);

            return View("AddSalary", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(SalaryViewModel model)
        {
            await _balanceService.AddSalaryAsync(model.Salary.Amount, model.Salary.Currency, model.ReceivedAt);
            return RedirectToAction("Index");
        }
    }
}