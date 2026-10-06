using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Soenneker.Blazor.SignaturePads.Dtos;
using Soenneker.Blazor.SignaturePads.Configuration;

namespace Soenneker.Blazor.SignaturePads;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(List<SignaturePadPointGroup>))]
[JsonSerializable(typeof(IReadOnlyList<SignaturePadPointGroup>))]
[JsonSerializable(typeof(SignaturePadOptions))]
[JsonSerializable(typeof(SignaturePadSvgOptions))]
[JsonSerializable(typeof(SignaturePadDataUrlOptions))]
internal partial class InteropJsonContext : JsonSerializerContext;
