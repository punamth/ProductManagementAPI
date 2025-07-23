using MediatR;
using ProductManagementAPI.Application.DTOs.Products;
using System.Collections.Generic;

namespace ProductManagementAPI.Application.Products.Queries
{
    // This query returns a list of ProductDto
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}