using MediatR;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserService _service;
        public DeleteUserCommandHandler(IUserService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteAsync(request.Id);
        }
    }
} 