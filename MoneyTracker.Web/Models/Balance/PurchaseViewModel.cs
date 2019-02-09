using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyTracker.Domain.ReadModel;

namespace MoneyTracker.Web.Models.Balance
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel()
        {
            Purchase = new MoneyViewModel();
            SpentAt = DateTime.UtcNow;
        }

        public PurchaseViewModel SetCurrencies(IEnumerable<CurrencyDto> currencies)
        {
            Currencies = currencies.Select(x => new SelectListItem(x.Code, x.Code));
            return this;
        }

        public MoneyViewModel Purchase { get; set; }
        public DateTime SpentAt { get; set; }
        public IEnumerable<SelectListItem> Currencies { get; set; } = new List<SelectListItem>();
    }
}