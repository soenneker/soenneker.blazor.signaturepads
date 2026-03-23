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
    /// Adds <see cref="ISignaturePadsInterop"/> and <see cref="ISignaturePad"/> as scoped services.
    /// </summary>
    public static IServiceCollection AddSignaturePadAsScoped(this IServiceCollection services)
    {
        services.AddResourceLoaderAsScoped()
                .TryAddScoped<ISignaturePadsInterop, SignaturePadsInterop>();

        services.TryAddScoped<ISignaturePad, SignaturePad>();

        return services;
    }
}
