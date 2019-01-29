using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;

namespace MoneyTracker.Web.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _balanceService.GetActualBalanceAsync();
            return View(accounts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await _balanceService.CreateAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(decimal amount)
        {
            //await _balanceService.AddExpenseAsync(
            //    new Money(amount, Currency.Byn),
            //    DateTime.Now,
            //    ExpenseType.Purchase);

            return RedirectToAction("Index");
        }

        // TODO: demo case, remove
        [HttpPost]
        public async Task<IActionResult> AddIncome()
        {
            //await _balanceService.AddIncomeAsync(
            //    new Money(amount, Currency.Byn),
            //    DateTime.Now);

            return RedirectToAction("Index");
        }
    }
}