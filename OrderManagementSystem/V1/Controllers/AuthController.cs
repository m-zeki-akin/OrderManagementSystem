using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Models;
using OrderManagementSystem.Models.Enums;
using OrderManagementSystem.Services;
using OrderManagementSystem.V1.Requests;
using OrderManagementSystem.V1.Responses;

namespace OrderManagementSystem.V1.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterUserRequest request)
    {
        var result = await authService.RegisterAsync(request.Email, request.Password, Roles.Customer);

        if (!result.IsSuccess)
        {
            return BadRequest(new {result.Error?.Message, result.Error?.Code});
        }

        var response = new RegisterUserResponse
        {
            Token = result.Value!,
            Email = request.Email,
            Role = Roles.Customer
        };
        
        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        var result = await authService.LoginAsync(request.Email, request.Password);

        if (!result.IsSuccess)
        {
            return BadRequest(new {result.Error?.Message, result.Error?.Code});
        }

        var response = new LoginUserResponse
        {
            Token = result.Value!,
            Email = request.Email,
        };
        
        return Ok(response);
    }
}