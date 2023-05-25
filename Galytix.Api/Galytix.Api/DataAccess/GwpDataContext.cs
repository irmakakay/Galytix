using Galytix.Api.Exceptions;
using Galytix.Api.Model.Import;

namespace Galytix.Api.DataAccess;

public class GwpDataContext : IGwpDataContext
{
    private readonly ILogger<GwpDataContext> _logger;

    public GwpDataContext(ILogger<GwpDataContext> logger)
        => _logger = logger;

    public Dictionary<string, Dictionary<string, double>> GwpLookup { get; } = new();

    public void Initialize(IEnumerable<GrossWrittenPremium> items)
    {
        try
        {
            var groupedByCountry = items.GroupBy(i => i.Country);

            foreach (var group in groupedByCountry)
            {
                var inner = group
                    .ToDictionary(g => g.LineOfBusiness, g => g.GetAverage());

                if (!GwpLookup.TryGetValue(group.Key, out _))
                {
                    GwpLookup[group.Key] = inner;
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating the internal lookup.");
            throw new DataContextException(e);
        }
    }
}