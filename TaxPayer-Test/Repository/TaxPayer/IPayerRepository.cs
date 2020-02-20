using System.Threading.Tasks;
using TaxPayer.Model;

namespace TaxPayer.Repository.TaxPayer
{
    public interface IPayerRepository
    {
        Task<Payer> GetByCPF(string cpf);
        Task Add(Payer data);
        Task Update(Payer data);
        Task Delete(Payer data);
    }
}
