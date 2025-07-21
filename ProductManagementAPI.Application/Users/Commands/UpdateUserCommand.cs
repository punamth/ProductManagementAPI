using MediatR;
using ProductManagementAPI.Application.DTOs.Users;

namespace ProductManagementAPI.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; }
        public UpdateUserDto Dto { get; }
        public UpdateUserCommand(int id, UpdateUserDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
} 