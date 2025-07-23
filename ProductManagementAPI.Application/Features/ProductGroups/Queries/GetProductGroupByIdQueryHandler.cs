using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.ProductGroups.Queries
{
    public class GetProductGroupByIdQueryHandler : IRequestHandler<GetProductGroupByIdQuery, ProductGroupDto?>
    {
        private readonly IProductGroupService _service;
        public GetProductGroupByIdQueryHandler(IProductGroupService service)
        {
            _service = service;
        }
        public async Task<ProductGroupDto?> Handle(GetProductGroupByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
} 