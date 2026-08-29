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
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the Signature Pads is ready for use.</returns>
    ValueTask Initialize(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a signature pad instance on the specified canvas element.
    /// </summary>
    /// <param name="elementReference">Element Reference for the create operation.</param>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="options">Options to configure for the signature pads.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the create operation is complete.</returns>
    ValueTask Create(ElementReference elementReference, string elementId, SignaturePadOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Attaches a resize observer to the existing canvas so the signature can be redrawn after size changes.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="preserveDrawingOnResize">Whether preserve drawing on resize.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the resize observer creation is complete.</returns>
    ValueTask CreateResizeObserver(string elementId, bool preserveDrawingOnResize = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes the resize observer for the specified canvas.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the destroy resize observer operation is complete.</returns>
    ValueTask DestroyResizeObserver(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Destroys the signature pad instance and any related observers.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the destroy operation is complete.</returns>
    ValueTask Destroy(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears the current signature.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the Signature Pads has been cleared.</returns>
    ValueTask Clear(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns true when the current signature pad is empty.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>true if the signature pad contains no strokes; otherwise, false.</returns>
    ValueTask<bool> IsEmpty(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exports the current signature as a data URL.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="type">Runtime type to inspect or construct.</param>
    /// <param name="encoderOptions">Encoder Options for the to data url operation.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the text returned by to Data URL.</returns>
    ValueTask<string> ToDataUrl(string elementId, string type = "image/png", double? encoderOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Exports the current signature as SVG markup.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="options">Options to configure for the signature pads.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the text returned by to Svg.</returns>
    ValueTask<string> ToSvg(string elementId, SignaturePadSvgOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the current signature stroke data.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the collection returned by to Data.</returns>
    ValueTask<IReadOnlyList<SignaturePadPointGroup>> ToData(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rehydrates the canvas from previously exported stroke data.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="data">data to process.</param>
    /// <param name="clear">Whether clear.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the from data operation is complete.</returns>
    ValueTask FromData(string elementId, IReadOnlyList<SignaturePadPointGroup> data, bool clear = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Draws an existing image onto the canvas.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="dataUrl">URL of the data to target.</param>
    /// <param name="options">Options to configure for the signature pads.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the from data url operation is complete.</returns>
    ValueTask FromDataUrl(string elementId, string dataUrl, SignaturePadDataUrlOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Redraws the current internal stroke data onto the canvas.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the redraw operation is complete.</returns>
    ValueTask Redraw(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Enables pointer listeners on the signature pad.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the on operation is complete.</returns>
    ValueTask On(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables pointer listeners on the signature pad.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the off operation is complete.</returns>
    ValueTask Off(string elementId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates writable signature pad options on the current instance.
    /// </summary>
    /// <param name="elementId">ID of the DOM element to target.</param>
    /// <param name="options">Options to configure for the signature pads.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task that completes when the options has been stored.</returns>
    ValueTask SetOptions(string elementId, SignaturePadOptions options, CancellationToken cancellationToken = default);
}
