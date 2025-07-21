using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;

namespace ProductManagementAPI.Application.ProductGroups.Commands
{
    public class CreateProductGroupCommand : IRequest<ProductGroupDto>
    {
        public CreateProductGroupDto Dto { get; }
        public CreateProductGroupCommand(CreateProductGroupDto dto)
        {
            Dto = dto;
        }
    }
} 