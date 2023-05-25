using System.Diagnostics.CodeAnalysis;

namespace Galytix.Api.Model.Entities;

[ExcludeFromCodeCoverage]
public class AverageGwpQuery
{
    public string Country { get; set; }
    
    public IEnumerable<string> LinesOfBusiness { get; set; }
}