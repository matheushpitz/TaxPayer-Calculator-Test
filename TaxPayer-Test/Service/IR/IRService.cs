using TaxPayer.ViewModel;

namespace TaxPayer.Service.IR
{
    public class IRService : IIRService
    {
        public void ApplyIR(decimal minimumSalary, PayerViewModel payer)
        {
            payer.NetSalary = payer.GrossSalary - this.GetIRDiscount(minimumSalary, payer);
        }

        public decimal GetDependentDiscount(decimal minimumSalary, PayerViewModel payer)
        {
            return (minimumSalary * 0.05m * payer.NumberDependents);
        }

        public decimal GetIRDiscount(decimal minimumSalary, PayerViewModel payer)
        {
            decimal result = 0;

            if((minimumSalary * 7) < payer.GrossSalary)
            {
                result = payer.GrossSalary * 0.275m;
            } else if ((minimumSalary * 5) < payer.GrossSalary)
            {
                result = payer.GrossSalary * 0.225m;                
            } else if ((minimumSalary * 4) < payer.GrossSalary)
            {
                result = payer.GrossSalary * 0.15m;                
            } else if ((minimumSalary * 2) < payer.GrossSalary)
            {
                result = payer.GrossSalary * 0.075m;                
            }

            result -= this.GetDependentDiscount(minimumSalary, payer);

            return result > 0 ? result : 0;
        }
    }
}
