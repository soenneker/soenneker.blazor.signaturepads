using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Soenneker.Blazor.SignaturePads.Configuration;
using Soenneker.Blazor.SignaturePads.Dtos;

namespace Soenneker.Blazor.SignaturePads.Abstract;

/// <summary>
/// Blazor interop for browser-facing signature pad functionality.
/// </summary>
public interface ISignaturePadsInterop : System.IAsyncDisposable
{
    /// <summary>
    /// Ensures the JavaScript dependencies for this package have been loaded.
    /// </summary>
    ValueTask Initialize(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a signature pad instance on the specified canvas element.
    /// </summary>
    ValueTask Create(ElementReference elementReference, string elementId, SignaturePadOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Attaches a resize observer to the existing canvas so the signature can be redrawn after size changes.
    /// </summary>
    ValueTask CreateResizeObserver(string elementId, bool preserveDrawingOnResize = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes the resize observer for the specified canvas.
    /// </summary>
    ValueTask DestroyResizeObserver(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Destroys the signature pad instance and any related observers.
    /// </summary>
    ValueTask Destroy(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears the current signature.
    /// </summary>
    ValueTask Clear(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns true when the current signature pad is empty.
    /// </summary>
    ValueTask<bool> IsEmpty(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exports the current signature as a data URL.
    /// </summary>
    ValueTask<string> ToDataUrl(string elementId, string type = "image/png", double? encoderOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exports the current signature as SVG markup.
    /// </summary>
    ValueTask<string> ToSvg(string elementId, SignaturePadSvgOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the current signature stroke data.
    /// </summary>
    ValueTask<IReadOnlyList<SignaturePadPointGroup>> ToData(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rehydrates the canvas from previously exported stroke data.
    /// </summary>
    ValueTask FromData(string elementId, IReadOnlyList<SignaturePadPointGroup> data, bool clear = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Draws an existing image onto the canvas.
    /// </summary>
    ValueTask FromDataUrl(string elementId, string dataUrl, SignaturePadDataUrlOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Redraws the current internal stroke data onto the canvas.
    /// </summary>
    ValueTask Redraw(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables pointer listeners on the signature pad.
    /// </summary>
    ValueTask On(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables pointer listeners on the signature pad.
    /// </summary>
    ValueTask Off(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates writable signature pad options on the current instance.
    /// </summary>
    ValueTask SetOptions(string elementId, SignaturePadOptions options, CancellationToken cancellationToken = default);
}
