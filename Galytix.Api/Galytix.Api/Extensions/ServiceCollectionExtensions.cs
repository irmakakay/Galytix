using System.Diagnostics.CodeAnalysis;

namespace Galytix.Api.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterAndValidateSettings<TSetting>(this IServiceCollection services,
        string sectionName)
        where TSetting : class
    {
        services
            .AddOptions<TSetting>()
            .BindConfiguration(sectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}