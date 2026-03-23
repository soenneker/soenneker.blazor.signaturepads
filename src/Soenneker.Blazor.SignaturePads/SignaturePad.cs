using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Blazor.SignaturePads.Abstract;

namespace Soenneker.Blazor.SignaturePads;

/// <inheritdoc cref="ISignaturePad"/>
public sealed class SignaturePad : ISignaturePad
{
    private readonly ISignaturePadsInterop _interop;

    public SignaturePad(ISignaturePadsInterop interop)
    {
        _interop = interop ?? throw new ArgumentNullException(nameof(interop));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask Initialize(CancellationToken cancellationToken = default)
    {
        return _interop.Initialize(cancellationToken);
    }
}
