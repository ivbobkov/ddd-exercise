using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Domain.ReadModel;
using MoneyTracker.Web.Models.Balance;

namespace MoneyTracker.Web.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IProvideCurrency _provideCurrency;
        private readonly ISalaryService _salaryService;

        public SalaryController(IProvideCurrency provideCurrency, ISalaryService salaryService)
        {
            _provideCurrency = provideCurrency;
            _salaryService = salaryService;
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
            await _salaryService.AddSalaryAsync(model.Salary.Amount, model.Salary.Currency, model.ReceivedAt);
            return RedirectToAction("Index", "Balance");
        }
    }
}
