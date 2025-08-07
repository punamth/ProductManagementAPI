using MediatR;
using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Application.DTOs.Auth;

namespace ProductManagementAPI.Application.Auth.Queries
{
    public class LoginUserQuery : IRequest<User?>
    {
        public LoginDto Dto { get; }
        public LoginUserQuery(LoginDto dto)
        {
            Dto = dto;
        }
    }
}