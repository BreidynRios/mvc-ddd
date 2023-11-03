using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class DBOrderContext : DbContext, IUnitOfWork
    {
        public DBOrderContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
