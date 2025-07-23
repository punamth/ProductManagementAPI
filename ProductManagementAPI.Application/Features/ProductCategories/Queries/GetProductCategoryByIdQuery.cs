using MediatR;
using ProductManagementAPI.Application.DTOs.ProductCategories;

namespace ProductManagementAPI.Application.ProductCategories.Queries
{
    public class GetProductCategoryByIdQuery : IRequest<ProductCategoryDto?>
    {
        public int Id { get; }
        public GetProductCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
} 