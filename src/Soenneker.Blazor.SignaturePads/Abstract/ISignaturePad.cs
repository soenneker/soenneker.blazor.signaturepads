using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Blazor.SignaturePads.Abstract;

/// <summary>
/// A higher-level Blazor utility built on top of <see cref="ISignaturePadsInterop"/>.
/// </summary>
public interface ISignaturePad
{
    /// <summary>
    /// Ensures the underlying JavaScript module has been loaded and is ready for use.
    /// </summary>
    ValueTask Initialize(CancellationToken cancellationToken = default);
}
