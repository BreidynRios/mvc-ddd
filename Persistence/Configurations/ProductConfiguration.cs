using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Producto");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Codigo");

            builder.Property(c => c.Description)
                .HasColumnName("Descripcion")
                .HasMaxLength(500);
        }
    }
}
