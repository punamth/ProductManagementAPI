using MediatR;
using ProductManagementAPI.Application.DTOs.Products;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductService _productService;
        
        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;
        }
        
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetByIdAsync(request.Id);
        }
    }
} 