using MediatR;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.ProductCategories.Commands
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, bool>
    {
        private readonly IProductCategoryService _service;
        public DeleteProductCategoryCommandHandler(IProductCategoryService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteAsync(request.Id);
        }
    }
} 