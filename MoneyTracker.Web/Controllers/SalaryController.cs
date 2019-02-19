using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;
using MoneyTracker.Web.ViewModels.Salary;

namespace MoneyTracker.Web.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IActionResult> AddSalary()
        {
            var viewModel = new SalaryViewModel();

            return View("InputForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalary([FromForm]SalaryViewModel model)
        {
            await _salaryService.AddSalaryAsync(model.Salary.Amount, model.Salary.Currency, model.ReceivedAt);
            return RedirectToAction("Index", "Home");
        }
    }
}
