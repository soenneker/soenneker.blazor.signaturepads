using System.Text.Json.Serialization;

namespace Soenneker.Blazor.SignaturePads.Configuration;

/// <summary>
/// Options for drawing an existing image onto the canvas via <c>fromDataURL()</c>.
/// </summary>
public sealed class SignaturePadDataUrlOptions
{
    [JsonPropertyName("ratio")]
    public double? Ratio { get; set; }

    [JsonPropertyName("width")]
    public double? Width { get; set; }

    [JsonPropertyName("height")]
    public double? Height { get; set; }

    [JsonPropertyName("xOffset")]
    public double? XOffset { get; set; }

    [JsonPropertyName("yOffset")]
    public double? YOffset { get; set; }
}
