using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.Core;
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
            var viewModel = new PurchaseViewModel(_provideCurrency.FindAll());

            return View("AddPurchase", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPurchase(PurchaseViewModel model)
        {
            await _balanceService.AddPurchaseAsync(new Money(model.Purchase.Amount, model.Purchase.Currency), model.SpentAt);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddSalary()
        {
            var viewModel = new SalaryViewModel(_provideCurrency.FindAll());

            return View("AddSalary", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(SalaryViewModel model)
        {
            await _balanceService.AddSalaryAsync(new Money(model.Salary.Amount, model.Salary.Currency), model.ReceivedAt);
            return RedirectToAction("Index");
        }
    }
}