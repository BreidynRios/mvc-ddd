using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("DetallePedido");

            builder.HasKey(dp => dp.Id);

            builder.Property(dp => dp.Id)
                .HasColumnName("IdDetalle");

            builder.Property(dp => dp.OrderId)
                .HasColumnName("IdOrden");

            builder.Property(dp => dp.ProductId)
                .HasColumnName("CodigoProducto");

            builder.Property(dp => dp.Description)
                .HasColumnName("Descripcion")
                .HasMaxLength(500);

            builder.Property(dp => dp.Quantity)
                .HasColumnName("Cantidad");

            builder.Property(dp => dp.UnitPrice)
                .HasColumnName("PrecioUnitario")
                .HasPrecision(18, 2);

            builder.Property(dp => dp.SubTotal)
                .HasColumnName("SubTotal")
                .HasPrecision(18, 2);

            builder.HasOne(p => p.Product)
                .WithMany(dp => dp.OrderDetails)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedido_Producto");

            builder.HasOne(p => p.Order)
                .WithMany(dp => dp.OrderDetails)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallePedido_Orden");
        }
    }
}
