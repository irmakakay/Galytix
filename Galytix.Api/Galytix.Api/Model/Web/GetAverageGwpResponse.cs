using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Galytix.Api.Model.Web;

[ExcludeFromCodeCoverage]
public class GetAverageGwpResponse
{
    [JsonPropertyName("transport")]
    public double? Transport { get; set; } 
    
    [JsonPropertyName("freight")]
    public double? Freight { get; set; } 
    
    [JsonPropertyName("property")]
    public double? Property { get; set; } 
    
    [JsonPropertyName("liability")]
    public double? Liability { get; set; } 
    
    [JsonPropertyName("a_s")]
    public double? A_s { get; set; } 
    
    [JsonPropertyName("other")]
    public double? Other { get; set; } 
    
    [JsonPropertyName("motor")]
    public double? Motor { get; set; } 
}