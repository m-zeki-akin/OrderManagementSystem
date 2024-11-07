namespace OrderManagementSystem.Common.Results;

public class Result<T>
{
    public T? Value { get; set; }
    public bool IsSuccess { get; set; }
    public Error? Error { get; set; }

    private Result(T? value, bool isSuccess, Error? error = null)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result<T> Success(T value) => new(value, true);
    public static Result<T> Failure(Error error) => new(default, false, error);
}