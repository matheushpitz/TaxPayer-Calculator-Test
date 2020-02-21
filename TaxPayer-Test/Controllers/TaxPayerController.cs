using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxPayer.Service.TaxPayer;
using TaxPayer.ViewModel;

namespace TaxPayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxPayerController : ControllerBase
    {
        private readonly IPayerService _service;

        public TaxPayerController(IPayerService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddPayerViewModel data)
        {
            bool success = await this._service.Add(data.minimumSalary, data.payers);
            if(success)
            {
                return Ok(new
                {
                    success,
                    data = data.payers,
                    message = "Contribuintes cadastrados com sucesso"
                });
            } else
            {
                return Ok(new
                {
                    success,
                    message = "Erro ao cadastrar os contribuintes"
                });
            }            
        }
        [HttpGet("has")]
        public async Task<IActionResult> Has(string cpf)
        {
            return Ok(new
            {
                has = await this._service.HasPayer(cpf)
            });
        }
    }
}