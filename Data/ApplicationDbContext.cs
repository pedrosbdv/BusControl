using BusControl.Models;
using Microsoft.EntityFrameworkCore;

namespace BusControl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<ViagensModel> Viagens { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
