using TaxPayer.ViewModel;

namespace TaxPayer.Service.IR
{
    public interface IIRService
    {
        void ApplyIR(decimal minimumSalary, PayerViewModel payer);
    }
}
