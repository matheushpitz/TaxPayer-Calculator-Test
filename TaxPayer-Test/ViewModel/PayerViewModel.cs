namespace TaxPayer.ViewModel
{
    public class PayerViewModel
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public int NumberDependents { get; set; }
        public decimal NetSalary { get; set; }
        public decimal GrossSalary { get; set; }
    }
}
