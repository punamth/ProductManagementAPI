using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.ProductGroups.Commands
{
    public class CreateProductGroupCommandHandler : IRequestHandler<CreateProductGroupCommand, ProductGroupDto>
    {
        private readonly IProductGroupService _service;
        public CreateProductGroupCommandHandler(IProductGroupService service)
        {
            _service = service;
        }
        public async Task<ProductGroupDto> Handle(CreateProductGroupCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateAsync(request.Dto);
        }
    }
} 