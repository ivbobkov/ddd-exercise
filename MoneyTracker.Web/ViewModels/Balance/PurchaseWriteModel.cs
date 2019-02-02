using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Web.ViewModels.Balance
{
    public class PurchaseWriteModel
    {
        public Money Purchase { get; set; }
        public DateTime SpentAt { get; set; }
    }
}