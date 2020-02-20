using System.Collections.Generic;

namespace TaxPayer.ViewModel
{
    public class AddPayerViewModel
    {
        public decimal minimumSalary { get; set; }
        public IEnumerable<PayerViewModel> payers { get; set; }
    }
}
