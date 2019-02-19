﻿using System;

namespace MoneyTracker.Web.ViewModels.Salary
{
    public class SalaryViewModel
    {
        public SalaryViewModel()
        {
            Salary = new MoneyViewModel();
            ReceivedAt = DateTime.UtcNow;
        }

        public MoneyViewModel Salary { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}