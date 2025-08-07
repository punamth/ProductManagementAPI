using MediatR;
using ProductManagementAPI.Application.DTOs.Users;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserService _service;
        public UpdateUserCommandHandler(IUserService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateAsync(request.Id, request.Dto);
        }
    }
} 