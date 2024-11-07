using OrderManagementSystem.Models.Enums;

namespace OrderManagementSystem.V1.Responses;

public class RegisterUserResponse
{
    public string Token { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}