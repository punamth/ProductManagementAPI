using ProductManagementAPI.Domain.Entities;
using ProductManagementAPI.Application.Interfaces.Services;
using ProductManagementAPI.Application.Interfaces.Repositories;
using ProductManagementAPI.Application.DTOs.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        var existingUser = (await _userRepository.GetAllAsync()).Any(u => u.Username == dto.Username);
        if (existingUser)
            return false;

        CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = hash,
            PasswordSalt = salt,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);
        return true;
    }

    public async Task<User?> ValidateUserAsync(LoginDto dto)
    {
        var user = (await _userRepository.GetAllAsync()).SingleOrDefault(u => u.Username == dto.Username);
        if (user == null || !VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            return null;
        return user;
    }

    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var user = await ValidateUserAsync(dto);
        if (user == null)
            return null;
        // JWT generation should be handled in the API layer, so return null or throw NotImplementedException if needed
        return null;
    }

    private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            salt = hmac.Key;
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(hash);
        }
    }
}