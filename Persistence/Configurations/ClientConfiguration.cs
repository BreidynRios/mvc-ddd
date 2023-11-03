using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Codigo");

            builder.Property(c => c.Name)
                .HasColumnName("Nombres")
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .HasColumnName("Apellidos")
                .HasMaxLength(50);

            builder.Property(c => c.DocumentNumber)
                .HasColumnName("DNI")
                .HasMaxLength(8);
        }
    }
}
