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
            Salary = new MoneyViewModel();
            ReceivedAt = DateTime.UtcNow;
        }

        public SalaryViewModel SetCurrencies(IEnumerable<CurrencyDto> currencies)
        {
            Currencies = currencies.Select(x => new SelectListItem(x.Code, x.Code));
            return this;
        }

        public MoneyViewModel Salary { get; set; }
        public DateTime ReceivedAt { get; set; }

        public IEnumerable<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();
    }
}
