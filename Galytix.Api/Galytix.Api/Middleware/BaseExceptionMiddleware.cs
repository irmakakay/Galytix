namespace Galytix.Api.Middleware;

using System.Net;

public abstract class BaseExceptionMiddleware<TMiddleware>
{
    private readonly ILogger<TMiddleware> _logger;

    private readonly RequestDelegate _next;

    protected BaseExceptionMiddleware(RequestDelegate next, ILogger<TMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error during executing {Context}", context.Request.Path.Value);
            var response = context.Response;
            response.ContentType = "application/json";
            
            var (status, message) = GetResponse(e);
            response.StatusCode = (int) status;
            await response.WriteAsync(message);
        }
    }
    
    protected abstract (HttpStatusCode code, string message) GetResponse(Exception exception);
}