using MediatR;
using ProductManagementAPI.Application.DTOs.ProductCategories;

namespace ProductManagementAPI.Application.ProductCategories.Commands
{
    public class CreateProductCategoryCommand : IRequest<ProductCategoryDto>
    {
        public CreateProductCategoryDto Dto { get; }
        public CreateProductCategoryCommand(CreateProductCategoryDto dto)
        {
            Dto = dto;
        }
    }
} 