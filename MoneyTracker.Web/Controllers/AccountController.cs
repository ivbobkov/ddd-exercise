using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.AggregatesModel.AccountAggregate;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await accountService.GetAllAccountsAsync();
            return View(accounts);
        }

        [HttpGet]
        public async Task<IActionResult> AddAccount()
        {
            await accountService.CreateAccountAsync();
            return RedirectToAction("Index");
        }

        // TODO: demo case, remove
        [HttpGet]
        public async Task<IActionResult> AddExpense(Guid accountId, string expenseId, decimal amount)
        {
            await accountService.AddExpenseAsync(
                accountId,
                expenseId,
                new Money(amount, Currency.Byn),
                DateTime.Now,
                ExpenseType.Purchase);

            return RedirectToAction("Index");
        }

        // TODO: demo case, remove
        [HttpGet]
        public async Task<IActionResult> AddIncome(Guid accountId, string expenseId, decimal amount)
        {
            await accountService.AddIncomeAsync(
                accountId,
                new Money(amount, Currency.Byn),
                DateTime.Now);

            return RedirectToAction("Index");
        }
    }
}