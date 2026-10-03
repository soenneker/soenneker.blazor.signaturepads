using Soenneker.Blazor.SignaturePads.Configuration;

namespace Soenneker.Blazor.SignaturePads;

internal readonly record struct SignaturePadOptionsSnapshot(double? DotSize, double? MinWidth, double? MaxWidth,
    int? Throttle, int? MinDistance, string? BackgroundColor, string? PenColor, double? VelocityFilterWeight,
    string? CompositeOperation)
{
    internal static SignaturePadOptionsSnapshot From(SignaturePadOptions options) => new(options.DotSize,
        options.MinWidth, options.MaxWidth, options.Throttle, options.MinDistance, options.BackgroundColor,
        options.PenColor, options.VelocityFilterWeight, options.CompositeOperation);
}
