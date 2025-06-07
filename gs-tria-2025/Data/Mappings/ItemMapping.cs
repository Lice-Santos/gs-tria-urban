using gs_tria_2025.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace gs_tria_2025.Data.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Itens");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.Categoria)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
