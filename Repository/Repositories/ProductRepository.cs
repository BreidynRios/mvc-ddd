using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBOrderContext _context;
        public ProductRepository(DBOrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> List()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
