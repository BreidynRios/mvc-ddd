using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("IdOrden");

            builder.Property(p => p.ClientId)
                .HasColumnName("CodigoCliente");

            builder.Property(p => p.Date)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

            builder.Property(p => p.Total)
                .HasColumnName("Total")
                .HasPrecision(18, 2);

            builder.HasOne(c => c.Client)
                .WithMany(p => p.Orders)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Cliente");
        }
    }
}
