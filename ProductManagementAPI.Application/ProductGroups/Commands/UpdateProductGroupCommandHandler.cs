using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.ProductGroups.Commands
{
    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, bool>
    {
        private readonly IProductGroupService _service;
        public UpdateProductGroupCommandHandler(IProductGroupService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(UpdateProductGroupCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateAsync(request.Id, request.Dto);
        }
    }
} 