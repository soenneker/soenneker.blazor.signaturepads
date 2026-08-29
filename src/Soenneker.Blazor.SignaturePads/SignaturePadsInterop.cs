using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Soenneker.Asyncs.Initializers;
using Soenneker.Blazor.SignaturePads.Configuration;
using Soenneker.Blazor.SignaturePads.Dtos;
using Soenneker.Blazor.Utils.ModuleImport.Abstract;
using Soenneker.Blazor.Utils.ResourceLoader.Abstract;
using Soenneker.Extensions.CancellationTokens;
using Soenneker.Utils.CancellationScopes;
using Soenneker.Blazor.SignaturePads.Abstract;

namespace Soenneker.Blazor.SignaturePads;

/// <inheritdoc cref="ISignaturePadsInterop"/>
public sealed class SignaturePadsInterop : ISignaturePadsInterop
{
    private const string _modulePath = "_content/Soenneker.Blazor.SignaturePads/js/signaturepadsinterop.js";
    private const string _cdnScriptPath = "https://cdn.jsdelivr.net/npm/signature_pad@5.1.4/dist/signature_pad.umd.min.js";
    private const string _cdnScriptIntegrity = "sha256-DYq7w7p8ljuA7cpV0a7QQ4O2GU6atSHKl3qDL5sNxcQ=";
    private const string _globalVariable = "SignaturePad";
    private const string _jsCreate = "create";
    private const string _jsCreateResizeObserver = "createResizeObserver";
    private const string _jsDestroyResizeObserver = "destroyResizeObserver";
    private const string _jsDestroy = "destroy";
    private const string _jsClear = "clear";
    private const string _jsIsEmpty = "isEmpty";
    private const string _jsToDataUrl = "toDataUrl";
    private const string _jsToSvg = "toSvg";
    private const string _jsToData = "toData";
    private const string _jsFromData = "fromData";
    private const string _jsFromDataUrl = "fromDataUrl";
    private const string _jsRedraw = "redraw";
    private const string _jsOn = "on";
    private const string _jsOff = "off";
    private const string _jsSetOptions = "setOptions";

    private readonly IResourceLoader _resourceLoader;
    private readonly IModuleImportUtil _moduleImportUtil;
    private readonly AsyncInitializer _initializer;
    private readonly CancellationScope _cancellationScope = new();

    private bool _disposed;

    public SignaturePadsInterop(IResourceLoader resourceLoader, IModuleImportUtil moduleImportUtil)
    {
        _resourceLoader = resourceLoader;
        _moduleImportUtil = moduleImportUtil;
        _initializer = new AsyncInitializer(InitializeModule);
    }

    private async ValueTask InitializeModule(CancellationToken cancellationToken)
    {
        await _resourceLoader.LoadScriptAndWaitForVariable(_cdnScriptPath, _globalVariable, _cdnScriptIntegrity, cancellationToken: cancellationToken);

        _ = await _moduleImportUtil.GetContentModuleReference(_modulePath, cancellationToken);
    }

    private async ValueTask EnsureInitialized(CancellationToken cancellationToken)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await _initializer.Init(linked);
        }
    }

    public async ValueTask Initialize(CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
            await EnsureInitialized(linked);
    }

    public async ValueTask Create(ElementReference elementReference, string elementId, SignaturePadOptions? options = null, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsCreate, linked, elementReference, elementId, options);
        }
    }

    public async ValueTask CreateResizeObserver(string elementId, bool preserveDrawingOnResize = true, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsCreateResizeObserver, linked, elementId, preserveDrawingOnResize);
        }
    }

    public async ValueTask DestroyResizeObserver(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsDestroyResizeObserver, linked, elementId);
        }
    }

    public async ValueTask Destroy(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsDestroy, linked, elementId);
        }
    }

    public async ValueTask Clear(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsClear, linked, elementId);
        }
    }

    public async ValueTask<bool> IsEmpty(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            return await module.InvokeAsync<bool>(_jsIsEmpty, linked, elementId);
        }
    }

    public async ValueTask<string> ToDataUrl(string elementId, string type = "image/png", double? encoderOptions = null, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            return await module.InvokeAsync<string>(_jsToDataUrl, linked, elementId, type, encoderOptions);
        }
    }

    public async ValueTask<string> ToSvg(string elementId, SignaturePadSvgOptions? options = null, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            return await module.InvokeAsync<string>(_jsToSvg, linked, elementId, options);
        }
    }

    public async ValueTask<IReadOnlyList<SignaturePadPointGroup>> ToData(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            List<SignaturePadPointGroup>? data = await module.InvokeAsync<List<SignaturePadPointGroup>>(_jsToData, linked, elementId);
            return data ?? [];
        }
    }

    public async ValueTask FromData(string elementId, IReadOnlyList<SignaturePadPointGroup> data, bool clear = true, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsFromData, linked, elementId, data, clear);
        }
    }

    public async ValueTask FromDataUrl(string elementId, string dataUrl, SignaturePadDataUrlOptions? options = null, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsFromDataUrl, linked, elementId, dataUrl, options);
        }
    }

    public async ValueTask Redraw(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsRedraw, linked, elementId);
        }
    }

    public async ValueTask On(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsOn, linked, elementId);
        }
    }

    public async ValueTask Off(string elementId, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsOff, linked, elementId);
        }
    }

    public async ValueTask SetOptions(string elementId, SignaturePadOptions options, CancellationToken cancellationToken = default)
    {
        CancellationToken linked = _cancellationScope.CancellationToken.Link(cancellationToken, out CancellationTokenSource? source);

        using (source)
        {
            await EnsureInitialized(linked);
            IJSObjectReference module = await _moduleImportUtil.GetContentModuleReference(_modulePath, linked);
            await module.InvokeVoidAsync(_jsSetOptions, linked, elementId, options);
        }
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
            return;

        _disposed = true;

        await _cancellationScope.DisposeAsync();
        await _initializer.DisposeAsync();
        await _moduleImportUtil.DisposeContentModule(_modulePath);
    }
}
