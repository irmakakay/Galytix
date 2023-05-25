using System.Text.Json;

namespace Galytix.Api.Services;

public interface ISerializationService
{
    T Deserialize<T>(string serialized, JsonSerializerOptions settings = default);

    string Serialize(object instance, JsonSerializerOptions settings = default);
}