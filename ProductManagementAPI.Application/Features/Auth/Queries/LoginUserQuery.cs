using MediatR;
using ProductManagementAPI.Application.DTOs.Auth;

namespace ProductManagementAPI.Application.Auth.Queries
{
    public class LoginUserQuery : IRequest<string?>
    {
        public LoginDto Dto { get; }
        public LoginUserQuery(LoginDto dto)
        {
            Dto = dto;
        }
    }
} 