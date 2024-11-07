namespace OrderManagementSystem.Common.Results;

public class Error(string message, string? code = null)
{
    public string Message { get; set; } = message;
    public string? Code { get; set; } = code;
}