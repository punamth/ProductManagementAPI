using MediatR;
using ProductManagementAPI.Application.DTOs.ProductCategories;
using ProductManagementAPI.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.ProductCategories.Queries
{
    public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IEnumerable<ProductCategoryDto>>
    {
        private readonly IProductCategoryService _service;
        public GetAllProductCategoriesQueryHandler(IProductCategoryService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
} 