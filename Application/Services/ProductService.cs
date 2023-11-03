using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Repository.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> List()
        {
            var clientes = await _productRepository.List();
            return _mapper.Map<IEnumerable<ProductDto>>(clientes);
        }
    }
}
