namespace Castle.Utils.ErrorHandling;

public class Error
{
    public static Error Create(string code, string message, ErrorType type) => new Error(code, message, type);

    public string Code { get; }
    public string Message { get; }
    public ErrorType Type { get; }

    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

}
