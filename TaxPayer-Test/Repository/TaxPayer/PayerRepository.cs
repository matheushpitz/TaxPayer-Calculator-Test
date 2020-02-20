using System.Threading.Tasks;
using TaxPayer.Database.Context;
using TaxPayer.Model;

namespace TaxPayer.Repository.TaxPayer
{
    public class PayerRepository : BaseRepository, IPayerRepository
    {        

        public PayerRepository(DbAppContext context): base(context) {}

        public async Task Add(Payer data)
        {
            await this._context.Set<Payer>().AddAsync(data);
        }

        public async Task Delete(Payer data)
        {
            await Task.FromResult(this._context.Set<Payer>().Remove(data));
        }

        public async Task<Payer> GetByCPF(string cpf)
        {
            return await this._context.Set<Payer>().FindAsync(cpf);
        }

        public async Task Update(Payer data)
        {
            Payer current = await this.GetByCPF(data.CPF);

            if(current != null)
            {
                this._context.Entry(current).CurrentValues.SetValues(data);
            }
        }
    }
}
