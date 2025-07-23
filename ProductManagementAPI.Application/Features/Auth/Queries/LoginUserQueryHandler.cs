using MediatR;
using ProductManagementAPI.Application.Interfaces.Services;

namespace ProductManagementAPI.Application.Auth.Queries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string?>
    {
        private readonly IAuthService _authService;
        public LoginUserQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<string?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.Dto);
        }
    }
} 