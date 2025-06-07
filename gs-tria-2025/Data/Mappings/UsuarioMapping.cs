using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(80);

            builder.Property(u => u.Senha)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(30);
            builder.Property(u => u.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(150);

//          Relacionamento

            builder.HasOne(u => u.Endereco)
                   .WithMany()
                   .HasForeignKey(u => u.IdEndereco);

//          Nome da coluna no banco de dados

            builder.Property(u => u.IdEndereco)
                .HasColumnName("EnderecoId");

        }
    }
}
