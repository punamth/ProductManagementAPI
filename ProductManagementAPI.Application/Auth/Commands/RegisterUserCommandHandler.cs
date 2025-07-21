using MediatR;
using ProductManagementAPI.Application.DTOs.Auth;
using ProductManagementAPI.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.Auth.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IAuthService _authService;
        public RegisterUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterAsync(request.Dto);
        }
    }
} 