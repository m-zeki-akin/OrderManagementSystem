using OrderManagementSystem.Models.Enums;

namespace OrderManagementSystem.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public OrderStatus Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
}