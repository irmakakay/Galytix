using Galytix.Api.DataAccess;
using Galytix.Api.Model.Entities;
using Moq;
using Xunit;

namespace Galytix.Api.UnitTests;

public class GwpDataRepositoryTests : BaseServiceTests<GwpDataRepository>
{
    private readonly Mock<IGwpDataContext> _contextMock = new();

    [Fact]
    public async Task WhenCountryIsInvalid_GetAveragesThrowsInvalidOperationException()
    {
        var query = GetInstance<AverageGwpQuery>();
        
        _contextMock
            .SetupGet(c => c.GwpLookup)
            .Returns(new Dictionary<string, Dictionary<string, double>>());

        var sut = new GwpDataRepository(_contextMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(() => sut.GetAverages(query));
    }

    [Fact]
    public async Task WhenCountryIsContextLookup_GetAveragesReturnsResultSet()
    {
        const string country = "ae";
        var query = GetInstance<AverageGwpQuery>();
        query.Country = country;
        var resultSet = new Dictionary<string, Dictionary<string, double>>
        {
            [country] = new()
            {
                { "lob1", 1.1 }
            }
        };

        _contextMock
            .SetupGet(c => c.GwpLookup)
            .Returns(resultSet)
            .Verifiable();

        var sut = new GwpDataRepository(_contextMock.Object);

        var result = await sut.GetAverages(query);
        
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        
        _contextMock.VerifyAll();
    }
}