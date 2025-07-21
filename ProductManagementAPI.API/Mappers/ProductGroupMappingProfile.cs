using AutoMapper;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Mappers
{
    public class ProductGroupMappingProfile : Profile
    {
        public ProductGroupMappingProfile()
        {
            CreateMap<ProductGroup, ProductGroupDto>();
            CreateMap<CreateProductGroupDto, ProductGroup>();
            CreateMap<UpdateProductGroupDto, ProductGroup>();
        }
    }
}