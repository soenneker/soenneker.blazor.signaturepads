using System.Text.Json.Serialization;

namespace Soenneker.Blazor.SignaturePads.Configuration;

/// <summary>
/// Options for creating SVG output from the current signature.
/// </summary>
public sealed class SignaturePadSvgOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether include background color.
    /// </summary>
    [JsonPropertyName("includeBackgroundColor")]
    public bool IncludeBackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether include data url.
    /// </summary>
    [JsonPropertyName("includeDataUrl")]
    public bool IncludeDataUrl { get; set; }
}
