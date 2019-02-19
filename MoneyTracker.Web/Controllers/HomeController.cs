using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application;

namespace MoneyTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBalanceService _balanceService;

        public HomeController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accounts = await _balanceService.GetActualBalanceAsync();
            return View(accounts);
        }
    }
}