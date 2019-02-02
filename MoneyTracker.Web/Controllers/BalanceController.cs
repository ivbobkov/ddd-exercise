using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.Core;

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

        [HttpPost]
        public async Task<IActionResult> AddPurchase(Money expense, DateTime spentAt)
        {
            await _balanceService.AddPurchaseAsync(expense, spentAt);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary(Money salary, DateTime receivedAt)
        {
            await _balanceService.AddSalaryAsync(salary, receivedAt);
            return RedirectToAction("Index");
        }
    }
}