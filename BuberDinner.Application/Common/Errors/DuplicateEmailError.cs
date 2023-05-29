namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailError : Exception
{
    public DuplicateEmailError() : base()
    {
    }

    public DuplicateEmailError(string? message) : base(message)
    {
    }

    public DuplicateEmailError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}