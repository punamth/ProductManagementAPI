using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;

namespace ProductManagementAPI.Application.ProductGroups.Commands
{
    public class UpdateProductGroupCommand : IRequest<bool>
    {
        public int Id { get; }
        public UpdateProductGroupDto Dto { get; }
        public UpdateProductGroupCommand(int id, UpdateProductGroupDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
} 