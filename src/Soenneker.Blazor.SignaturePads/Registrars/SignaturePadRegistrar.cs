using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Blazor.SignaturePads.Abstract;
using Soenneker.Blazor.Utils.ResourceLoader.Registrars;

namespace Soenneker.Blazor.SignaturePads.Registrars;

/// <summary>
/// Registration for the interop and utility services.
/// </summary>
public static class SignaturePadRegistrar
{
    /// <summary>
    /// Adds <see cref="ISignaturePadsInterop"/> as scoped services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddSignaturePadAsScoped(this IServiceCollection services)
    {
        services.AddResourceLoaderAsScoped()
                .TryAddScoped<ISignaturePadsInterop, SignaturePadsInterop>();

        return services;
    }
}
