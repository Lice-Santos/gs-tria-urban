using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gs_tria_2025.Data.Mappings
{
    public class PontoDistribuicaoMapping : IEntityTypeConfiguration<PontoDistribuicao>
    {
        public void Configure(EntityTypeBuilder<PontoDistribuicao> builder)
        {
            builder.ToTable("PontosDistribuicao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Tipo)
                   .IsRequired();

//      Relacionamento One to Many
            builder.HasOne(p => p.Endereco)
                   .WithMany()
                   .HasForeignKey(p => p.IdEndereco);

            builder.HasOne(p => p.Usuario)
                   .WithMany()
                   .HasForeignKey(p => p.IdUsuario);
        }
    }
}
