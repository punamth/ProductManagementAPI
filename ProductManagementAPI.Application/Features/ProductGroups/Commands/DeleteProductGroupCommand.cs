using MediatR;

namespace ProductManagementAPI.Application.ProductGroups.Commands
{
    public class DeleteProductGroupCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteProductGroupCommand(int id)
        {
            Id = id;
        }
    }
} 