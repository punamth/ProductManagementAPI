using MediatR;

namespace ProductManagementAPI.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
} 