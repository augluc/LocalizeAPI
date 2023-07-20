namespace Core.Exceptions;

[Serializable]
public class InvalidUserCredentialsException : Exception
{
    private const string defaultMessage = "Username or password is incorrect";
    public InvalidUserCredentialsException() : base(defaultMessage)
    {
    }
}