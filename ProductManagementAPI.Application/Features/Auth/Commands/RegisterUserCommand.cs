using MediatR;
using ProductManagementAPI.Application.DTOs.Auth;

namespace ProductManagementAPI.Application.Auth.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public RegisterDto Dto { get; }
        public RegisterUserCommand(RegisterDto dto)
        {
            Dto = dto;
        }
    }
} 