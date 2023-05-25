using Galytix.Api.Model.Entities;

namespace Galytix.Api.DataAccess;

public class GwpDataRepository : IGwpDataRepository
{
    private readonly IGwpDataContext _dataContext;

    public GwpDataRepository(IGwpDataContext dataContext)
        => _dataContext = dataContext;
    
    public async Task<Dictionary<string, double>> GetAverages(AverageGwpQuery query)
    {
        if (_dataContext.GwpLookup.TryGetValue(query.Country, out var inner))
        {
            return await Task.FromResult(inner);
        }

        throw new InvalidOperationException();
    }
}