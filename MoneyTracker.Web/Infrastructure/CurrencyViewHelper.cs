using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Web.Infrastructure
{
    public class CurrencyViewHelper
    {
        private readonly IProvideCurrency _provideCurrency;

        public CurrencyViewHelper(IProvideCurrency provideCurrency)
        {
            _provideCurrency = provideCurrency;
        }

        public async Task<IEnumerable<SelectListItem>> AllAsync()
        {
            var currencies = await _provideCurrency.AllAsync();
            return currencies.Select(x => new SelectListItem(x.Code, x.Code));
        }
    }
}