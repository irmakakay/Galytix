using Galytix.Api.Model.Entities;
using Galytix.Api.Model.Web;

namespace Galytix.Api.DataAccess;

public interface IGwpDataRepository
{
    Task<Dictionary<string, double>> GetAverages(AverageGwpQuery query);
}