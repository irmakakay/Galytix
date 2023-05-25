using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Galytix.Api.Services;

[ExcludeFromCodeCoverage]
public class SerializationService : ISerializationService
{
    public T Deserialize<T>(string serialized, JsonSerializerOptions settings = default)
        => string.IsNullOrEmpty(serialized) ? 
            default : 
            JsonSerializer.Deserialize<T>(serialized, settings);

    public string Serialize(object instance, JsonSerializerOptions settings = default) 
        => JsonSerializer.Serialize(instance, settings);
}