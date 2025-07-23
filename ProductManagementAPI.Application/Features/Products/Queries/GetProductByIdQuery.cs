using MediatR;
using ProductManagementAPI.Application.DTOs.Products;

namespace ProductManagementAPI.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto?>
    {
        public int Id { get; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
} 