namespace Castle.Utils.ErrorHandling;

public class Result
{
    public static Result Success() => new(false, null);
    public static Result Failure(Error error) => new(true, error);

    public bool IsFailure { get; }
    public Error? Error { get; }

    protected Result(bool isFailure, Error? error)
    {
        IsFailure = isFailure;
        Error = error;
    }
}

public class Result<T> : Result
    where T : class
{

    public static Result<TResult> Success<TResult>(TResult value)
        where TResult : class
    {
        return new Result<TResult>(true, value, null);
    }

    public static Result<TResult> Failure<TResult>(Error error)
        where TResult : class
    {
        return new Result<TResult>(true, null, error);
    }

    public T? Value { get; }
    private Result(bool isFailure, T? value, Error? error) :
        base(isFailure, error)
    {
        Value = value;
    }
}
