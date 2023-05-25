using AutoMapper;
using Galytix.Api.DataAccess;
using Galytix.Api.Model.Entities;
using Galytix.Api.Model.Web;
using Galytix.Api.Services;
using Moq;
using Xunit;

namespace Galytix.Api.UnitTests;

public class GwpDataServiceTests : BaseServiceTests<GwpDataService>
{
    private readonly Mock<IGwpDataRepository> _dataRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    [Fact]
    public async Task WhenRequestIsNull_GetAverageGwpByCountryAndLinesOfBusinessThrowsException()
    {
        var sut = new GwpDataService(_dataRepositoryMock.Object, _mapperMock.Object, LoggerMock.Object);

        await Assert.ThrowsAsync<ArgumentException>(() => sut.GetAverageGwpByCountryAndLinesOfBusiness(null));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task WhenCountryInRequestIsNullOrEmpty_GetAverageGwpByCountryAndLinesOfBusinessThrowsException(
        string country)
    {
        var request = GetInstance<GetAverageGwpRequest>();
        request.Country = country;

        var sut = new GwpDataService(_dataRepositoryMock.Object, _mapperMock.Object, LoggerMock.Object);

        await Assert.ThrowsAsync<ArgumentException>(() => sut.GetAverageGwpByCountryAndLinesOfBusiness(request));
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public async Task WhenLineOfBusinessInRequestIsNullOrEmpty_GetAverageGwpByCountryAndLinesOfBusinessThrowsException(
        string lob)
    {
        var request = GetInstance<GetAverageGwpRequest>();
        request.LinesOfBusiness = request.LinesOfBusiness.Append(lob);

        var sut = new GwpDataService(_dataRepositoryMock.Object, _mapperMock.Object, LoggerMock.Object);

        await Assert.ThrowsAsync<ArgumentException>(() => sut.GetAverageGwpByCountryAndLinesOfBusiness(request));
    }

    [Fact]
    public async Task WhenRequestIsValid_GetAverageGwpByCountryAndLinesOfBusinessReturnsCollection()
    {
        const string key = "dict1";
        const double value = 1.1;
        var request = GetInstance<GetAverageGwpRequest>();
        var query = GetInstance<AverageGwpQuery>();
        query.LinesOfBusiness = query.LinesOfBusiness.Append(key);
        var dict = new Dictionary<string, double>
        {
            { key, value }
        };

        _mapperMock
            .Setup(m => m.Map<GetAverageGwpRequest, AverageGwpQuery>(request))
            .Returns(query)
            .Verifiable();
        
        _dataRepositoryMock
            .Setup(r => r.GetAverages(query))
            .ReturnsAsync(dict)
            .Verifiable();
        
        var sut = new GwpDataService(_dataRepositoryMock.Object, _mapperMock.Object, LoggerMock.Object);

        var result = await sut.GetAverageGwpByCountryAndLinesOfBusiness(request);
        
        Assert.Equal(key, result.Keys.FirstOrDefault());
        Assert.Equal(value, result.Values.FirstOrDefault());
        
        _mapperMock.VerifyAll();
        _dataRepositoryMock.VerifyAll();
    }
}