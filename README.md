[![](https://img.shields.io/nuget/v/soenneker.blazor.signaturepads.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.signaturepads/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.signaturepads/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.signaturepads/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.signaturepads.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.signaturepads/)
[![](https://img.shields.io/badge/Demo-Live-blueviolet?style=for-the-badge&logo=github)](https://soenneker.github.io/soenneker.blazor.signaturepads)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.signaturepads/codeql.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.signaturepads/actions/workflows/codeql.yml)

# Soenneker.Blazor.SignaturePads

Blazor interop for browser-facing signature pad functionality.

## Install

```bash
dotnet add package Soenneker.Blazor.SignaturePads
```

## Quick start

```csharp
using Soenneker.Blazor.SignaturePads.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddSignaturePadAsScoped();
```

Adds `ISignaturePadsInterop` as scoped services.

## What you get

- `ISignaturePadsInterop` — Blazor interop for browser-facing signature pad functionality.
- `SignaturePadRegistrar` — Registration for the interop and utility services.
- `SignaturePadDataUrlOptions` — Options for drawing an existing image onto the canvas via `fromDataURL()`.
- `SignaturePadOptions` — Configuration options forwarded to the underlying `signature_pad` instance.
- `SignaturePadPoint` — Represents a single point in a signature stroke.
- `SignaturePadPointGroup` — Represents a stroke group returned by `signature_pad`.
- `SignaturePadSvgOptions` — Options for creating SVG output from the current signature.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `ISignaturePadsInterop.Initialize(cancellationToken)` | Ensures the JavaScript dependencies for this package have been loaded. | A task that completes when the Signature Pads is ready for use. |
| `ISignaturePadsInterop.Create(elementReference, elementId, options, cancellationToken)` | Creates a signature pad instance on the specified canvas element. | A task that completes when the create operation is complete. |
| `ISignaturePadsInterop.CreateResizeObserver(elementId, preserveDrawingOnResize, cancellationToken)` | Attaches a resize observer to the existing canvas so the signature can be redrawn after size changes. | A task that completes when the resize observer creation is complete. |
| `ISignaturePadsInterop.Destroy(elementId, cancellationToken)` | Destroys the signature pad instance and any related observers. | A task that completes when the destroy operation is complete. |
| `ISignaturePadsInterop.Clear(elementId, cancellationToken)` | Clears the current signature. | A task that completes when the Signature Pads has been cleared. |
| `ISignaturePadsInterop.IsEmpty(elementId, cancellationToken)` | Returns true when the current signature pad is empty. | true if the signature pad contains no strokes; otherwise, false. |
| `ISignaturePadsInterop.ToDataUrl(elementId, type, encoderOptions, cancellationToken)` | Exports the current signature as a data URL. | A task whose result is the text returned by to Data URL. |
| `ISignaturePadsInterop.ToSvg(elementId, options, cancellationToken)` | Exports the current signature as SVG markup. | A task whose result is the text returned by to Svg. |
| `ISignaturePadsInterop.ToData(elementId, cancellationToken)` | Returns the current signature stroke data. | The signature's current stroke data. |
| `ISignaturePadsInterop.FromData(elementId, data, clear, cancellationToken)` | Rehydrates the canvas from previously exported stroke data. | A task that completes when the from data operation is complete. |
| `ISignaturePadsInterop.FromDataUrl(elementId, dataUrl, options, cancellationToken)` | Draws an existing image onto the canvas. | A task that completes when the from data url operation is complete. |
| `ISignaturePadsInterop.Redraw(elementId, cancellationToken)` | Redraws the current internal stroke data onto the canvas. | A task that completes when the redraw operation is complete. |
| `ISignaturePadsInterop.On(elementId, cancellationToken)` | Enables pointer listeners on the signature pad. | A task that completes when the on operation is complete. |
| `ISignaturePadsInterop.Off(elementId, cancellationToken)` | Disables pointer listeners on the signature pad. | A task that completes when the off operation is complete. |
| `ISignaturePadsInterop.SetOptions(elementId, options, cancellationToken)` | Updates writable signature pad options on the current instance. | A task that completes when the options has been stored. |
| `SignaturePadRegistrar.AddSignaturePadAsScoped(services)` | Adds `ISignaturePadsInterop` as scoped services. | The same service collection, so additional registrations can be chained. |
| `SignaturePadDataUrlOptions.Ratio` | Gets or sets ratio. | Gets or sets ratio. |
| `SignaturePadDataUrlOptions.Width` | Gets or sets width. | Gets or sets width. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
