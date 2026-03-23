namespace Soenneker.Blazor.SignaturePads.Dtos;

/// <summary>
/// Represents a single point in a signature stroke.
/// </summary>
public sealed class SignaturePadPoint
{
    public long Time { get; set; }

    public double X { get; set; }

    public double Y { get; set; }

    public double Pressure { get; set; }
}
