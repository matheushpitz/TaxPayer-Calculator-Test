using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaxPayer.Database.Context;
using TaxPayer.Model;
using TaxPayer.Repository.TaxPayer;
using TaxPayer.Service.IR;
using TaxPayer.ViewModel;

namespace TaxPayer.Service.TaxPayer
{
    public class PayerService: BaseService, IPayerService
    {
        private readonly IPayerRepository _repository;
        private readonly IIRService _ir;

        public PayerService(DbAppContext context, IMapper mapper, IPayerRepository repository,
                            IIRService ir) : base(context, mapper)
        {
            this._repository = repository;
            this._ir = ir;
        }

        public async Task<bool> Add(decimal minimumSalary, IEnumerable<PayerViewModel> payers)
        {
            foreach(PayerViewModel p in payers)
            {
                this._ir.ApplyIR(minimumSalary, p);
                Payer model = this._mapper.Map<Payer>(p);
                if (await HasPayer(model.CPF))
                {
                    // Update if it exists
                    await this._repository.Update(model);
                } else
                {
                    await this._repository.Add(model);
                }                
            }

            return await this.Commit();
        }

        public async Task<bool> HasPayer(string cpf)
        {
            return await this._repository.GetByCPF(cpf) != null;
        }
    }
}
