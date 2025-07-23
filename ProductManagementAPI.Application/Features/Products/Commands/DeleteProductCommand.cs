using MediatR;

namespace ProductManagementAPI.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
} 