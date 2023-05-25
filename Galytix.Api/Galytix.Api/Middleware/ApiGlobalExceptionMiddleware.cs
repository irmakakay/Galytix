using System.Net;
using Galytix.Api.Exceptions;
using Galytix.Api.Model.Web;
using Galytix.Api.Services;

namespace Galytix.Api.Middleware;

public class ApiGlobalExceptionMiddleware : BaseExceptionMiddleware<ApiGlobalExceptionMiddleware>
{
    private readonly ISerializationService _serializationService;

    public ApiGlobalExceptionMiddleware(
        RequestDelegate next,
        ISerializationService serializationService,
        ILogger<ApiGlobalExceptionMiddleware> logger)
        : base(next, logger)
    {
        _serializationService = serializationService;
    }

    protected override (HttpStatusCode code, string message) GetResponse(Exception exception)
    {
        var code = exception switch
        {
            GetGwpAveragesException => HttpStatusCode.NotFound,
            ArgumentException or
                ArgumentNullException or
                InvalidOperationException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        return (code, _serializationService.Serialize(new ApiError(code, exception.Message)));
    }
}