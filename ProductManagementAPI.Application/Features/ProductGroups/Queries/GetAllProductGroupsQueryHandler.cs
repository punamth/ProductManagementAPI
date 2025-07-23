using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using ProductManagementAPI.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.ProductGroups.Queries
{
    public class GetAllProductGroupsQueryHandler : IRequestHandler<GetAllProductGroupsQuery, IEnumerable<ProductGroupDto>>
    {
        private readonly IProductGroupService _service;
        public GetAllProductGroupsQueryHandler(IProductGroupService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<ProductGroupDto>> Handle(GetAllProductGroupsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
} 