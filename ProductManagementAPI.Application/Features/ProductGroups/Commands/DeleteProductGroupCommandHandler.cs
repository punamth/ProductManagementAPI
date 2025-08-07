using MediatR;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.ProductGroups.Commands
{
    public class DeleteProductGroupCommandHandler : IRequestHandler<DeleteProductGroupCommand, bool>
    {
        private readonly IProductGroupService _service;
        public DeleteProductGroupCommandHandler(IProductGroupService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(DeleteProductGroupCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteAsync(request.Id);
        }
    }
} 