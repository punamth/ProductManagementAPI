using MediatR;
using ProductManagementAPI.Application.DTOs.Products;

namespace ProductManagementAPI.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public CreateProductDto Dto { get; }
        public CreateProductCommand(CreateProductDto dto)
        {
            Dto = dto;
        }
    }
}
