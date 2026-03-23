using System.Text.Json.Serialization;

namespace Soenneker.Blazor.SignaturePads.Configuration;

/// <summary>
/// Options for creating SVG output from the current signature.
/// </summary>
public sealed class SignaturePadSvgOptions
{
    [JsonPropertyName("includeBackgroundColor")]
    public bool IncludeBackgroundColor { get; set; }

    [JsonPropertyName("includeDataUrl")]
    public bool IncludeDataUrl { get; set; }
}
