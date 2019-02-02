using System;
using MoneyTracker.Domain.Core;

namespace MoneyTracker.Web.ViewModels.Balance
{
    public class SalaryWriteModel
    {
        public Money Salary { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
