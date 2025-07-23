using AutoMapper;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Mappers
{
    public class ProductGroupMappingProfile : Profile
    {
        public ProductGroupMappingProfile()
        {
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();

            var createMap = CreateMap<CreateProductGroupDto, ProductGroup>();
            createMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            createMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            createMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            createMap.ForMember(dest => dest.Categories, opt => opt.Ignore());

            var updateMap = CreateMap<UpdateProductGroupDto, ProductGroup>();
            updateMap.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            updateMap.ForMember(dest => dest.Id, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            updateMap.ForMember(dest => dest.Categories, opt => opt.Ignore());
        }
    }
}