using System.Collections.Generic;

namespace Soenneker.Blazor.SignaturePads.Dtos;

/// <summary>
/// Represents a stroke group returned by <c>signature_pad</c>.
/// </summary>
public sealed class SignaturePadPointGroup
{
    public List<SignaturePadPoint> Points { get; set; } = [];

    public string? PenColor { get; set; }

    public double? DotSize { get; set; }

    public double? MinWidth { get; set; }

    public double? MaxWidth { get; set; }

    public double? VelocityFilterWeight { get; set; }

    public string? CompositeOperation { get; set; }
}
