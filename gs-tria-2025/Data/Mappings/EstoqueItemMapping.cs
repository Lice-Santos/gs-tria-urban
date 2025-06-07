using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Data.Mappings
{
    public class EstoqueItemMapping : IEntityTypeConfiguration<EstoqueItem>
    {
        public void Configure(EntityTypeBuilder<EstoqueItem> builder)
        {
            builder.ToTable("Estoques");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Quantidade)
                   .IsRequired();

            builder.Property(e => e.DataAtualizacao);

        //Relacionamento One to Many
            builder.HasOne(e => e.Item)
                   .WithMany()
                   .HasForeignKey(e => e.IdItem);

            builder.HasOne(e => e.PontoDistribuicao)
                   .WithMany()
                   .HasForeignKey(e => e.IdPontoDistribuicao);
        }
    }
}
