using MediatR;
using ProductManagementAPI.Application.DTOs.Products;

namespace ProductManagementAPI.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; }
        public UpdateProductDto Dto { get; }
        public UpdateProductCommand(int id, UpdateProductDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
} 