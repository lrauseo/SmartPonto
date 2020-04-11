using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using SmartPonto.Api.Models;
using SmartPonto.Api.Repository.Mapping;

namespace SmartPonto.Api.Repository
{
    public class PontoDB : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<PontoRegistro> ProntoRegistros { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public PontoDB(DbContextOptions<PontoDB> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Ignore<Configuracao>();
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LoginMap());                          
        }
    }
}