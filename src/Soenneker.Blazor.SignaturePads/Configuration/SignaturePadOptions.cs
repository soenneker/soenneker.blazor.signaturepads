using System.Text.Json.Serialization;

namespace Soenneker.Blazor.SignaturePads.Configuration;

/// <summary>
/// Configuration options forwarded to the underlying <c>signature_pad</c> instance.
/// </summary>
public sealed class SignaturePadOptions
{
    /// <summary>
    /// Gets or sets dot size.
    /// </summary>
    [JsonPropertyName("dotSize")]
    public double? DotSize { get; set; }

    /// <summary>
    /// Gets or sets min width.
    /// </summary>
    [JsonPropertyName("minWidth")]
    public double? MinWidth { get; set; }

    /// <summary>
    /// Gets or sets max width.
    /// </summary>
    [JsonPropertyName("maxWidth")]
    public double? MaxWidth { get; set; }

    /// <summary>
    /// Gets or sets throttle.
    /// </summary>
    [JsonPropertyName("throttle")]
    public int? Throttle { get; set; }

    /// <summary>
    /// Gets or sets min distance.
    /// </summary>
    [JsonPropertyName("minDistance")]
    public int? MinDistance { get; set; }

    /// <summary>
    /// Gets or sets background color.
    /// </summary>
    [JsonPropertyName("backgroundColor")]
    public string? BackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets pen color.
    /// </summary>
    [JsonPropertyName("penColor")]
    public string? PenColor { get; set; }

    /// <summary>
    /// Gets or sets velocity filter weight.
    /// </summary>
    [JsonPropertyName("velocityFilterWeight")]
    public double? VelocityFilterWeight { get; set; }

    /// <summary>
    /// Gets or sets composite operation.
    /// </summary>
    [JsonPropertyName("compositeOperation")]
    public string? CompositeOperation { get; set; }
}
