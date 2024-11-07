using MassTransit;
using OrderManagementSystem.Models;
using Serilog;

namespace OrderManagementSystem.Services;

public class MassTransitService(IPublishEndpoint publishEndpoint)
{
    public async Task PublishOrderAsync(Order order)
    {
        try
        {
            await publishEndpoint.Publish(order);
            Log.Information($"Order {order.Id} has been published to the RabbitMQ queue.");
        }
        catch (Exception ex)
        {
            Log.Information($"An error occurred while publishing the order: {ex.Message}");
        }
    }
}