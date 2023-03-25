

using Microsoft.EntityFrameworkCore;

namespace MVCPracticaUno.Models
{
    public class equiposDBContext : DbContext
    {
        public equiposDBContext(DbContextOptions options) : base(options) {
      
        }

        public DbSet<marcas> marcas { get; set; }

    }
}
