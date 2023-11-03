using Domain;
using Persistence.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly DBOrderContext _context;
        public OrderRepository(DBOrderContext context)
        {
            _context = context;
        }

        public async Task Save(Order order)
        {
            await _context.Orders.AddAsync(order);
        }
    }
}
