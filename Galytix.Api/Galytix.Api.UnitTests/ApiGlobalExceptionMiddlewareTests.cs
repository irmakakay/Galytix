using System.Net;
using System.Text.Json;
using Galytix.Api.Exceptions;
using Galytix.Api.Middleware;
using Galytix.Api.Model.Web;
using Galytix.Api.Services;
using Moq;
using Xunit;

namespace Galytix.Api.UnitTests;

public class ApiGlobalExceptionMiddlewareTests : BaseServiceTests<ApiGlobalExceptionMiddleware>
{
    private readonly Mock<ISerializationService> _serializationServiceMock = new();

    [Fact]
    public async Task WhenRequestDelegateThrowsException_GetResponseReturnCorrectResponse()
    {
        var httpContext = new DefaultHttpContext();

        async Task Next(HttpContext context)
        {
            await Task.FromException(new GetGwpAveragesException(new InvalidOperationException()));
        }

        var error = new ApiError(HttpStatusCode.NotFound, "Employee not found.");

        _serializationServiceMock
            .Setup(s => 
                s.Serialize(It.IsAny<ApiError>(), It.IsAny<JsonSerializerOptions>()))
            .Returns(JsonSerializer.Serialize(error))
            .Verifiable();
        
        var sut = new ApiGlobalExceptionMiddleware(Next, _serializationServiceMock.Object, LoggerMock.Object);

        await sut.Invoke(httpContext);
        
        _serializationServiceMock.Verify();
    }
}