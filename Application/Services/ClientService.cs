using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Repository.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(
            IClientRepository clientRepository,
            IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> List()
        {
            var clientes = await _clientRepository.List();
            return _mapper.Map<IEnumerable<ClientDto>>(clientes);
        }
    }
}
