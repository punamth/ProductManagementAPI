using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;
using System.Collections.Generic;

namespace ProductManagementAPI.Application.ProductGroups.Queries
{
    public class GetAllProductGroupsQuery : IRequest<IEnumerable<ProductGroupDto>>
    {
    }
} 