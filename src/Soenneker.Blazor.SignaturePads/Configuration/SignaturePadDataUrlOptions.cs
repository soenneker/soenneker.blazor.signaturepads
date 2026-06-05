using System.Text.Json.Serialization;

namespace Soenneker.Blazor.SignaturePads.Configuration;

/// <summary>
/// Options for drawing an existing image onto the canvas via <c>fromDataURL()</c>.
/// </summary>
public sealed class SignaturePadDataUrlOptions
{
    /// <summary>
    /// Gets or sets ratio.
    /// </summary>
    [JsonPropertyName("ratio")]
    public double? Ratio { get; set; }

    /// <summary>
    /// Gets or sets width.
    /// </summary>
    [JsonPropertyName("width")]
    public double? Width { get; set; }

    /// <summary>
    /// Gets or sets height.
    /// </summary>
    [JsonPropertyName("height")]
    public double? Height { get; set; }

    /// <summary>
    /// Gets or sets x offset.
    /// </summary>
    [JsonPropertyName("xOffset")]
    public double? XOffset { get; set; }

    /// <summary>
    /// Gets or sets y offset.
    /// </summary>
    [JsonPropertyName("yOffset")]
    public double? YOffset { get; set; }
}
