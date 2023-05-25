using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Galytix.Api.Model.Web;

[ExcludeFromCodeCoverage]
public class ApiError
{
    public ApiError(HttpStatusCode code, string message)
    {
        Code = code;
        Message = message;
    }
    
    public HttpStatusCode Code { get; }
    
    public string Message { get; }
}