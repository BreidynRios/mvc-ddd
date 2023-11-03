using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DBOrderContext _context;
        public ClientRepository(DBOrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> List()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
