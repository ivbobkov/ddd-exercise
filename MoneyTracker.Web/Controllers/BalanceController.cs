using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.Core;
using MoneyTracker.Web.Models.Balance;

namespace MoneyTracker.Web.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
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
            return View("AddPurchase");
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
            return View("AddSalary");
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(SalaryViewModel model)
        {
            await _balanceService.AddSalaryAsync(new Money(model.Salary.Amount, model.Salary.Currency), model.ReceivedAt);
            return RedirectToAction("Index");
        }
    }
}