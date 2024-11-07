using Microsoft.AspNetCore.Identity;
using OrderManagementSystem.Common.Results;
using OrderManagementSystem.Data.Repositories;
using OrderManagementSystem.Helpers;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.V1.Services;

public class AdminRegistrationService(
    IUserRepository userRepository,
    RoleManager roleManager)
    : IRegistrationService
{
    public async Task<Result<User>> RegisterAsync(string email, string password, Guid? requesterId)
    {
        if (requesterId == null || !await roleManager.CanAssignRoleAsync(requesterId.Value, Roles.Admin))
        {
            return Result<User>.Failure(new Error("Unauthorized to create Admin users", "UNAUTHORIZED"));
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = PasswordHasher.HashPassword(password),
            Role = Roles.Admin
        };

        await userRepository.AddUserAsync(user);
        return Result<User>.Success(user);
    }
}