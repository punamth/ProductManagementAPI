using MediatR;
using ProductManagementAPI.Application.DTOs.Users;
using System.Collections.Generic;

namespace ProductManagementAPI.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
} 