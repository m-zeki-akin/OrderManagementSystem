using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services;

public interface IRoleManager
{
    public Task<bool> CanAssignRoleAsync(Guid requesterId, string assignedRole);
}