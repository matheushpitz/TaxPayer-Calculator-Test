using AutoMapper;
using System.Threading.Tasks;
using TaxPayer.Database.Context;

namespace TaxPayer.Service
{
    public class BaseService
    {
        protected readonly DbAppContext _context;
        protected readonly IMapper _mapper;

        public BaseService(DbAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected async Task<bool> Commit()
        {
            return await this._context.SaveChangesAsync() > 0;
        }
    }
}
