namespace EduFlex.Domain.Exceptions;

public class EduFlexException : Exception
{
    public int statusCode { get; set; }

    public EduFlexException(int statusCode, string message) : base(message)
    {
        this.statusCode = statusCode;
    }
}
