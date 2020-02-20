using TaxPayer.Database.Context;

namespace TaxPayer.Repository
{
    public class BaseRepository
    {
        protected readonly DbAppContext _context;

        public BaseRepository(DbAppContext context)
        {
            _context = context;
        }
    }
}
