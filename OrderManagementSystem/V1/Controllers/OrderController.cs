using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.V1.Controllers;

[Route("v1/[controller]")]
[ApiController]
[Authorize]
public class OrderController(DataContext context, MassTransitService massTransitService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        context.Orders.Add(order);
        
        await context.SaveChangesAsync();
        await massTransitService.PublishOrderAsync(order);

        return Ok(order);
    }
}