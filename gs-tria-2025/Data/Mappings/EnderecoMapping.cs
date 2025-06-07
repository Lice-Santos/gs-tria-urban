using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gs_tria_2025.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(e => e.Uf)
                .IsRequired()
                .HasMaxLength(2); 

            builder.Property(e => e.Complemento)
                .HasMaxLength(100);
        }
        }
}
