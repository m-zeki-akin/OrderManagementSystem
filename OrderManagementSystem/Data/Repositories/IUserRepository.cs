using OrderManagementSystem.Models;

namespace OrderManagementSystem.Data.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User email);
}