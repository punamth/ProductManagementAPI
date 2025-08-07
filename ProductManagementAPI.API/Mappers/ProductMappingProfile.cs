using AutoMapper;
using ProductManagementAPI.Application.DTOs.Products;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            // Product to ProductDto mapping with ImageUrl
            CreateMap<ProductManagementAPI.Domain.Entities.Product, ProductDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageFileName != null ? $"/images/{src.ImageFileName}" : null));

            // CreateProductDto to Product mapping
            var createMap = CreateMap<CreateProductDto, ProductManagementAPI.Domain.Entities.Product>();
            createMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            createMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            createMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            createMap.ForMember(dest => dest.Category, opt => opt.Ignore());

            // UpdateProductDto to Product mapping
            var updateMap = CreateMap<UpdateProductDto, ProductManagementAPI.Domain.Entities.Product>();
            updateMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            updateMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}
