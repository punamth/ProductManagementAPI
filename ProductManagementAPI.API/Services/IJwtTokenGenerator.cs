using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}