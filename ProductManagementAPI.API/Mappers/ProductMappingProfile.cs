using AutoMapper;
using ProductManagementAPI.Application.DTOs.Products;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            var createMap = CreateMap<CreateProductDto, Product>();
            createMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            createMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            createMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            createMap.ForMember(dest => dest.Category, opt => opt.Ignore());

            var updateMap = CreateMap<UpdateProductDto, Product>();
            updateMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            updateMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
