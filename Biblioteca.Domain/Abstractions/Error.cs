using System.Net;

namespace Biblioteca.Domain.Abstractions;

public sealed class Error
{
    public required string Message { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public required string Code { get; set; }

    private Error() { }

    public static Error Create(string message, HttpStatusCode httpStatusCode, string code)
    {
        return new Error
        {
            Message = message,
            HttpStatusCode = httpStatusCode,
            Code = code
        };
    }
}
