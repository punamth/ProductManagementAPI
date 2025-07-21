using MediatR;
using ProductManagementAPI.Application.DTOs.ProductGroups;

namespace ProductManagementAPI.Application.ProductGroups.Queries
{
    public class GetProductGroupByIdQuery : IRequest<ProductGroupDto?>
    {
        public int Id { get; }
        public GetProductGroupByIdQuery(int id)
        {
            Id = id;
        }
    }
} 