using MediatR;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using System.Collections.Generic;

namespace ProductManagementAPI.Application.ProductCategories.Queries
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryDto>>
    {
    }
} 