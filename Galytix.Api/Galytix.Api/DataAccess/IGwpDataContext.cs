using Galytix.Api.Model.Import;

namespace Galytix.Api.DataAccess;

public interface IGwpDataContext
{
    Dictionary<string, Dictionary<string, double>> GwpLookup { get; }
    void Initialize(IEnumerable<GrossWrittenPremium> items);
}