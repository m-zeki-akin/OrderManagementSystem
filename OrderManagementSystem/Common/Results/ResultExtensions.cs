namespace OrderManagementSystem.Common.Results;

public static class ResultExtensions
{
    public static Result<T> ToResult<T>(this T value)
    {
        return Result<T>.Success(value);
    }

    public static Result<T> ToFailure<T>(this Error error)
    {
        return Result<T>.Failure(error);
    }
}