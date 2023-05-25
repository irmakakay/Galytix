using AutoFixture;
using Moq;

namespace Galytix.Api.UnitTests;

public abstract class BaseServiceTests<TService>
{
    private readonly Fixture _fixture = new();

    protected Mock<ILogger<TService>> LoggerMock => new();

    protected T GetInstance<T>() => _fixture.Create<T>();
    
    protected IEnumerable<T> GetInstances<T>(int many = 3) => _fixture.CreateMany<T>(many);
}