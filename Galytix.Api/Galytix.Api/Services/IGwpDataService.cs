using Galytix.Api.Model.Web;

namespace Galytix.Api.Services;

public interface IGwpDataService
{
    Task<Dictionary<string, double>> GetAverageGwpByCountryAndLinesOfBusiness(GetAverageGwpRequest request);
}