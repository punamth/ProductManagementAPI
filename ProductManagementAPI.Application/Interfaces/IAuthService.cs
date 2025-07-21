using ProductManagementAPI.Application.DTOs.Auth;

namespace ProductManagementAPI.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}