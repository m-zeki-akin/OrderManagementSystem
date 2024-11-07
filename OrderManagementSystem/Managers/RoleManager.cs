using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services;

public class RoleManager(DataContext context)
{
    public async Task<bool> CanAssignRoleAsync(Guid requesterId, string assignedRole)
    {
        var requester = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == requesterId);

        if (requester == null)
            throw new Exception("Requester not found");

        if (assignedRole == Roles.Admin && requester.Role != Roles.Manager)
        {
            return false;
        }

        return true;
    }

    public bool IsValidRole(string role)
    {
        return role == Roles.Admin || role == Roles.Customer || role == Roles.Manager;
    }
}