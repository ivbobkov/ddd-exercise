using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Web.Models.Balance
{
    public class SalaryViewModel
    {
        public SalaryViewModel()
        {
        }

        public SalaryViewModel(IEnumerable<CurrencyDto> currencies)
        {
            Currencies = currencies.Select(x => new SelectListItem(x.Code, x.Code));
        }

        public MoneyViewModel Salary { get; set; }
        public DateTime ReceivedAt { get; set; }

        public IEnumerable<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();
    }
}
