using System.Collections.Generic;

namespace TaxPayer.ViewModel
{
    public class AddPayerViewModel
    {
        public decimal MinimumSalary { get; set; }
        public IEnumerable<PayerViewModel> Payers { get; set; }
    }
}
