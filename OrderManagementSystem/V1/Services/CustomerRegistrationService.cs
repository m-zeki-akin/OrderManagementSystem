using Microsoft.AspNetCore.Identity;
using OrderManagementSystem.Common.Results;
using OrderManagementSystem.Data.Repositories;
using OrderManagementSystem.Helpers;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.V1.Services;

public class CustomerRegistrationService(IUserRepository userRepository) : IRegistrationService
{
    public async Task<Result<User>> RegisterAsync(string email, string password, Guid? requesterId)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = PasswordHasher.HashPassword(password),
            Role = Roles.Customer
        };

        await userRepository.AddUserAsync(user);
        return Result<User>.Success(user);
    }

}