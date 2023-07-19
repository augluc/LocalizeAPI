namespace Core.Exceptions;

[Serializable]
public class NotFoundException : Exception
{
    private const string defaultMessage = "Resource not found";
    public NotFoundException() : base(defaultMessage)
    {
    }
}