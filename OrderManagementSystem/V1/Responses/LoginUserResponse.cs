using OrderManagementSystem.Models.Enums;

namespace OrderManagementSystem.V1.Responses;

public class LoginUserResponse
{
    public string Token { get; set; }
    public string Email { get; set; }
}