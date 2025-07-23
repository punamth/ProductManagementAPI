using MediatR;

namespace ProductManagementAPI.Application.ProductCategories.Commands
{
    public class DeleteProductCategoryCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteProductCategoryCommand(int id)
        {
            Id = id;
        }
    }
} 