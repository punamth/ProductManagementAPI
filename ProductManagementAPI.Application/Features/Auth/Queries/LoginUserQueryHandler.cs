using MediatR;
using ProductManagementAPI.Application.Interfaces.Services;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.Application.Auth.Queries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User?>
    {
        private readonly IAuthService _authService;
        public LoginUserQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<User?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            return await _authService.ValidateUserAsync(request.Dto);
        }
    }
}