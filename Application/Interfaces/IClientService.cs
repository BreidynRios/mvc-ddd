using Application.Dtos;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> List();
    }
}
