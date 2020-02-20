using System.Collections.Generic;
using System.Threading.Tasks;
using TaxPayer.ViewModel;

namespace TaxPayer.Service.TaxPayer
{
    public interface IPayerService
    {
        Task<bool> Add(decimal minimumSalary, IEnumerable<PayerViewModel> payers);
        Task<bool> HasPayer(string cpf);
    }
}
