using AutoMapper;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Mappers
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<CreateProductCategoryDto, ProductCategory>();
            CreateMap<UpdateProductCategoryDto, ProductCategory>();
        }
    }
}