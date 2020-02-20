using Microsoft.EntityFrameworkCore;
using TaxPayer.Model;

namespace TaxPayer.Database.Context
{
    public class DbAppContext: DbContext
    {

        public DbSet<Payer> Teste { get; set; }

        public DbAppContext(DbContextOptions<DbAppContext> options) : base(options) { }
    }
}
