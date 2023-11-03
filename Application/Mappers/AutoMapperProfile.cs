using Application.Dtos;
using AutoMapper;
using Domain;

namespace Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();

            CreateMap<Client, ClientDto>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.LastName}"))
                .ReverseMap()
                .ForPath(s => s.Orders, opt => opt.Ignore());
        }
    }
}
