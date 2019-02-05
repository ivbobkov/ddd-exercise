using System.Collections.Generic;

namespace MoneyTracker.Domain.ReadModel
{
    public class BalanceDetailsDto
    {
        public IEnumerable<PurchaseDto> Purchases { get; set; } = new List<PurchaseDto>();
        public IEnumerable<SalaryDto> Salaries { get; set; } = new List<SalaryDto>();
    }
}
