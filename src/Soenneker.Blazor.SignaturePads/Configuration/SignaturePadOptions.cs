using System.Text.Json.Serialization;

namespace Soenneker.Blazor.SignaturePads.Configuration;

/// <summary>
/// Configuration options forwarded to the underlying <c>signature_pad</c> instance.
/// </summary>
public sealed class SignaturePadOptions
{
    [JsonPropertyName("dotSize")]
    public double? DotSize { get; set; }

    [JsonPropertyName("minWidth")]
    public double? MinWidth { get; set; }

    [JsonPropertyName("maxWidth")]
    public double? MaxWidth { get; set; }

    [JsonPropertyName("throttle")]
    public int? Throttle { get; set; }

    [JsonPropertyName("minDistance")]
    public int? MinDistance { get; set; }

    [JsonPropertyName("backgroundColor")]
    public string? BackgroundColor { get; set; }

    [JsonPropertyName("penColor")]
    public string? PenColor { get; set; }

    [JsonPropertyName("velocityFilterWeight")]
    public double? VelocityFilterWeight { get; set; }

    [JsonPropertyName("compositeOperation")]
    public string? CompositeOperation { get; set; }
}
