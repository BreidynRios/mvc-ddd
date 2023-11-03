using Domain;

namespace Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> List();
    }
}
