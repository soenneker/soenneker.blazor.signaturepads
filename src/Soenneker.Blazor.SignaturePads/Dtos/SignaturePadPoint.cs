namespace Soenneker.Blazor.SignaturePads.Dtos;

/// <summary>
/// Represents a single point in a signature stroke.
/// </summary>
public sealed class SignaturePadPoint
{
    /// <summary>
    /// Gets or sets time.
    /// </summary>
    public long Time { get; set; }

    /// <summary>
    /// Gets or sets x.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Gets or sets y.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets pressure.
    /// </summary>
    public double Pressure { get; set; }
}
