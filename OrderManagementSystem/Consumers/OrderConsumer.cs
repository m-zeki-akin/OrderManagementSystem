using MassTransit;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Models.Enums;

namespace OrderManagementSystem.Consumers;

public class OrderConsumer(DataContext context) : IConsumer<Order>
{
    public async Task Consume(ConsumeContext<Order> context1)
    {
        var order = context1.Message;
        
        order.Status = OrderStatus.Processing;
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }
}