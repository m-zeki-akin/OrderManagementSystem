using OrderManagementSystem.Common.Results;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.V1.Services;

public interface IRegistrationService
{
    Task<Result<User>> RegisterAsync(string email, string password, Guid? requesterId = null);
}