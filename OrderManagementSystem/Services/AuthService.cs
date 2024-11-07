using OrderManagementSystem.Common.Results;
using OrderManagementSystem.Data.Repositories;
using OrderManagementSystem.Helpers;
using OrderManagementSystem.Models;
using OrderManagementSystem.Models.Enums;

namespace OrderManagementSystem.Services;

public class AuthService(IUserRepository userRepository, TokenService tokenService)
{
    public async Task<Result<string>> RegisterAsync(string email, string password, string role)
    {
        if (await userRepository.GetUserByEmailAsync(email) != null)
        {
            return Result<string>.Failure(new Error("User already exists", "USER_ALREADY_EXISTS"));
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = PasswordHasher.HashPassword(password),
            Role = role
        };

        await userRepository.AddUserAsync(user);
        var token = tokenService.GenerateToken(user);
        
        return Result<string>.Success(token);
    }

    public async Task<Result<string>> LoginAsync(string email, string password)
    {
        var user  = await userRepository.GetUserByEmailAsync(email);

        if (user == null)
        {
            return Result<string>.Failure(new Error("User does not exist", "USER_NOT_EXISTS"));
        }

        if (user.PasswordHash != PasswordHasher.HashPassword(password))
        {
            return Result<string>.Failure(new Error("Wrong Password", "PASSWORD_INVALID"));
        }
        
        var token = tokenService.GenerateToken(user);
        return Result<string>.Success(token);
    }
    
}