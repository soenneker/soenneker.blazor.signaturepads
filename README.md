[![](https://img.shields.io/nuget/v/soenneker.blazor.signaturepads.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.signaturepads/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.signaturepads/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.signaturepads/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.signaturepads.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.signaturepads/)
[![](https://img.shields.io/badge/Demo-Live-blueviolet?style=for-the-badge&logo=github)](https://soenneker.github.io/soenneker.blazor.signaturepads)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.signaturepads/codeql.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.signaturepads/actions/workflows/codeql.yml)

# Soenneker.Blazor.SignaturePads

A Blazor component and JS interop wrapper for drawing, restoring, and exporting signatures with `signature_pad`.

[Live demo](https://soenneker.github.io/soenneker.blazor.signaturepads)

## Installation

```bash
dotnet add package Soenneker.Blazor.SignaturePads
```

Register the interop service in `Program.cs`:

```csharp
using Soenneker.Blazor.SignaturePads.Registrars;

builder.Services.AddSignaturePadAsScoped();
```

Add the component namespace to `_Imports.razor`:

```razor
@using Soenneker.Blazor.SignaturePads
```

## Basic usage

Give the canvas an explicit rendered size, wait for `OnReady`, and use the component reference for operations:

```razor
@using Soenneker.Blazor.SignaturePads.Configuration

<SignaturePadCanvas @ref="_signaturePad"
                    Style="width: 100%; height: 220px; border: 1px solid #bbb;"
                    Options="_options"
                    OnReady="HandleReady"
                    aria-label="Signature input" />

<button type="button" disabled="@(!_ready)" @onclick="ClearAsync">Clear</button>
<button type="button" disabled="@(!_ready)" @onclick="ExportAsync">Export PNG</button>

@if (_png is not null)
{
    <img src="@_png" alt="Signature preview" />
}

@code {
    private SignaturePadCanvas? _signaturePad;
    private bool _ready;
    private string? _png;

    private readonly SignaturePadOptions _options = new()
    {
        PenColor = "#111827",
        BackgroundColor = "rgb(255,255,255)",
        MinWidth = 0.8,
        MaxWidth = 2.2
    };

    private void HandleReady() => _ready = true;

    private async Task ClearAsync() => await _signaturePad!.Clear();

    private async Task ExportAsync()
    {
        if (!await _signaturePad!.IsEmpty())
            _png = await _signaturePad.ToDataUrl("image/png");
    }
}
```

Public component methods throw until the canvas has completed its first interactive render. `OnReady` is the safest point to enable controls that call them.

## Saving and restoring signatures

Choose the representation based on what you need later:

```csharp
// Editable stroke data: best for restoring and continuing to draw.
IReadOnlyList<SignaturePadPointGroup> strokes = await _signaturePad.ToData();
await _signaturePad.FromData(strokes);

// Raster output for display or upload.
string pngDataUrl = await _signaturePad.ToDataUrl("image/png");

// Generated SVG markup.
string svg = await _signaturePad.ToSvg();
```

`FromData(data, clear: true)` replaces existing strokes by default. Pass `clear: false` to append them. `FromDataUrl()` draws an image onto the canvas; it does not recreate editable stroke groups.

Data URLs contain a media-type prefix and Base64 payload. If an API expects bytes, remove the prefix and decode the payload before upload. Do not store large data URLs in normal form fields or logs.

## Resizing

`ObserveResize` defaults to `true` and scales the canvas backing buffer for the device pixel ratio. The canvas still needs a non-zero CSS width and height from your layout.

With `PreserveDrawingOnResize="true"`, existing point data is redrawn after a resize. Points retain their original canvas coordinates; changing the aspect ratio or making the canvas substantially smaller can clip or reposition the visible signature. Set it to `false` when a resize should clear the pad.

## Options and controls

`SignaturePadOptions` configures dot size, minimum and maximum line width, throttling, minimum point distance, background color, pen color, velocity filtering, and canvas compositing. Updated option values are applied after subsequent component renders, or immediately through `SetOptions()`.

The component also exposes:

- `Clear()` and `IsEmpty()`;
- `Enable()` and `Disable()` for pointer listeners;
- `ToData()`, `ToDataUrl()`, and `ToSvg()` for export;
- `FromData()`, `FromDataUrl()`, and `Redraw()` for restoration.

## Security and accessibility

- Signatures are sensitive personal data. Protect them in transit and storage, restrict access, and define retention rules appropriate to your application.
- Loading a remote image with `FromDataUrl()` can taint the canvas when the image server does not permit cross-origin use. A tainted canvas cannot be exported to PNG or SVG data successfully.
- `ToSvg()` returns markup. If you insert it as raw HTML, sanitize it according to your application's trust boundary; rendering it through an `<img>` data URL avoids direct DOM injection.
- A canvas is not an accessible substitute for consent or identity verification. Provide instructions, an accessible name, keyboard-operable controls, and an alternative completion method.

The package loads pinned `signature_pad` JavaScript from jsDelivr with subresource integrity validation. Applications that disallow third-party scripts must account for that origin in their Content Security Policy or provide an approved asset-loading strategy.
