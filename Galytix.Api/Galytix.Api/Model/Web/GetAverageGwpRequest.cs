using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Galytix.Api.Model.Web;

[ExcludeFromCodeCoverage]
public class GetAverageGwpRequest
{
    [Required]
    [JsonPropertyName("country")]
    public string Country { get; set; }
    
    [JsonPropertyName("lob")]
    public IEnumerable<string> LinesOfBusiness { get; set; }
}