using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.Core;
using MoneyTracker.Domain.WriteModel.BalanceAggregate;

namespace MoneyTracker.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBalanceService _balanceService;

        public AccountController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _balanceService.GetActualBalanceAsync();
            return View(accounts);
        }

        [HttpGet]
        public async Task<IActionResult> AddAccount()
        {
            await _balanceService.CreateAsync();
            return RedirectToAction("Index");
        }

        // TODO: demo case, remove
        [HttpGet]
        public async Task<IActionResult> AddExpense(Guid accountId, decimal amount)
        {
            await _balanceService.AddExpenseAsync(
                new Money(amount, Currency.Byn),
                DateTime.Now,
                ExpenseType.Purchase);

            return RedirectToAction("Index");
        }

        // TODO: demo case, remove
        [HttpGet]
        public async Task<IActionResult> AddIncome(Guid accountId, string expenseId, decimal amount)
        {
            await _balanceService.AddIncomeAsync(
                new Money(amount, Currency.Byn),
                DateTime.Now);

            return RedirectToAction("Index");
        }
    }
}