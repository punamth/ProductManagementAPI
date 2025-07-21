using MediatR;
using ProductManagementAPI.Application.DTOs.Users;
using ProductManagementAPI.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserService _service;
        public GetAllUsersQueryHandler(IUserService service)
        {
            _service = service;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
} 