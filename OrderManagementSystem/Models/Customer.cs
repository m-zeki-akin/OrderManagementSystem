namespace OrderManagementSystem.Models;

public class Customer
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public ICollection<Order> Orders { get; set; }

}