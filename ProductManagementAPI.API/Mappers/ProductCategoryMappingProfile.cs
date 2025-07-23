using AutoMapper;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Mappers
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();

            var createMap = CreateMap<CreateProductCategoryDto, ProductCategory>();
            createMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            createMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            createMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            createMap.ForMember(dest => dest.Group, opt => opt.Ignore());
            createMap.ForMember(dest => dest.Products, opt => opt.Ignore());

            var updateMap = CreateMap<UpdateProductCategoryDto, ProductCategory>();
            updateMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            updateMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.Group, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}