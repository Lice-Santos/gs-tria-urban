using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using gs_tria_2025.Models;
using gs_tria_2025.Data.Mappings;

namespace gs_tria_2025.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<PontoDistribuicao> PontosDistribuicao { get; set; }
        public DbSet<EstoqueItem> Estoques { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new ItemMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new PontoDistribuicaoMapping());
            modelBuilder.ApplyConfiguration(new EstoqueItemMapping());

        }
    }
}
