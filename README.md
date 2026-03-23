[![](https://img.shields.io/nuget/v/soenneker.blazor.signaturepads.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.signaturepads/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.signaturepads/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.signaturepads/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.signaturepads.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.signaturepads/)
[![](https://img.shields.io/badge/Demo-Live-blueviolet?style=for-the-badge&logo=github)](https://soenneker.github.io/soenneker.blazor.signaturepads)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.signaturepads/codeql.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.signaturepads/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Blazor.SignaturePads
### A Blazor library for drawing smooth signatures, an interop for signature_pad

## Installation

```bash
dotnet add package Soenneker.Blazor.SignaturePads
```

## Setup

Register services in `Program.cs`:

```csharp
builder.Services.AddSignaturePadAsScoped();
```

Inject the higher-level utility where you need it:

```csharp
@inject ISignaturePad SignaturePads
```

## Usage

Initialize the package once before first use:

```csharp
await SignaturePads.Initialize();
```
