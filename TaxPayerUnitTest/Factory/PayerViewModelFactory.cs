using TaxPayer.ViewModel;

namespace TaxPayerUnitTest.Factory
{
    public class PayerViewModelFactory
    {
        public static PayerViewModel CreatePayer(int numberDependents)
        {
            PayerViewModel result = new PayerViewModel();

            result.NumberDependents = numberDependents;

            return result;
        }

        public static PayerViewModel CreatePayer(int numberDependents, decimal grossSalary)
        {
            PayerViewModel result = new PayerViewModel();

            result.NumberDependents = numberDependents;
            result.GrossSalary = grossSalary;

            return result;
        }
    }
}
