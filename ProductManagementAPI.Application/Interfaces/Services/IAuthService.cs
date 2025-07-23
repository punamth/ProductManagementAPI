using ProductManagementAPI.Application.DTOs.Auth;
using ProductManagementAPI.Domain.Entities;
using System.Threading.Tasks;

namespace ProductManagementAPI.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
        Task<User?> ValidateUserAsync(LoginDto dto);
    }
}