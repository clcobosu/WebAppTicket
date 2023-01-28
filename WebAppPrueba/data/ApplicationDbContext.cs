using WebAppPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppPrueba.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<WebAppPrueba.Models.Ticket> Ticket { get; set; }
        public DbSet<WebAppPrueba.Models.Client> Client { get; set; }
        public DbSet<WebAppPrueba.Models.Operario> Operario { get; set; }
       
       
    }
}
