using MediatR;
using ProductManagementAPI.Application.DTOs.ProductCategories;

namespace ProductManagementAPI.Application.ProductCategories.Commands
{
    public class UpdateProductCategoryCommand : IRequest<bool>
    {
        public int Id { get; }
        public UpdateProductCategoryDto Dto { get; }
        public UpdateProductCategoryCommand(int id, UpdateProductCategoryDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
} 