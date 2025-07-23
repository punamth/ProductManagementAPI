using MediatR;
using ProductManagementAPI.Application.DTOs.Products;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.UpdateAsync(request.Id, request.Dto);
        }
    }
} 