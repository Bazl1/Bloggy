namespace Bloggy.Application.Common;

public class ApplicatioException : Exception
{
    public ApplicatioException()
    {
    }

    public ApplicatioException(string? message) : base(message)
    {
    }
}