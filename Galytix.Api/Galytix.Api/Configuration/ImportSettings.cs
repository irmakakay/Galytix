using System.Diagnostics.CodeAnalysis;

namespace Galytix.Api.Configuration;

[ExcludeFromCodeCoverage]
public class ImportSettings
{
    public string Source { get; set; }
    
    public IEnumerable<string> ColumnNames { get; set; }
}