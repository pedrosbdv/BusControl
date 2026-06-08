using BusControl.Models;
using Microsoft.EntityFrameworkCore;

namespace BusControl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<ViagemModel> Viagens { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<MotoristaModel> Motoristas { get; set; }

        public DbSet<VeiculoModel> Veiculos { get; set; }
    }
}
