using MediatR;
using ProductManagementAPI.Application.DTOs.Users;

namespace ProductManagementAPI.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public int Id { get; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
} 