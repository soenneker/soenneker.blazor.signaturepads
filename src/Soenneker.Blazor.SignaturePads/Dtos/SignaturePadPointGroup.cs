using System.Collections.Generic;

namespace Soenneker.Blazor.SignaturePads.Dtos;

/// <summary>
/// Represents a stroke group returned by <c>signature_pad</c>.
/// </summary>
public sealed class SignaturePadPointGroup
{
    /// <summary>
    /// Gets or sets points.
    /// </summary>
    public List<SignaturePadPoint> Points { get; set; } = [];

    /// <summary>
    /// Gets or sets pen color.
    /// </summary>
    public string? PenColor { get; set; }

    /// <summary>
    /// Gets or sets dot size.
    /// </summary>
    public double? DotSize { get; set; }

    /// <summary>
    /// Gets or sets min width.
    /// </summary>
    public double? MinWidth { get; set; }

    /// <summary>
    /// Gets or sets max width.
    /// </summary>
    public double? MaxWidth { get; set; }

    /// <summary>
    /// Gets or sets velocity filter weight.
    /// </summary>
    public double? VelocityFilterWeight { get; set; }

    /// <summary>
    /// Gets or sets composite operation.
    /// </summary>
    public string? CompositeOperation { get; set; }
}
