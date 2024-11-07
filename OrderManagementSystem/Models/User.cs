using OrderManagementSystem.Models.Enums;

namespace OrderManagementSystem.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
}