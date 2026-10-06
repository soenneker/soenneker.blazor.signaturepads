using System.Text.Json;
using Soenneker.Blazor.SignaturePads;

var groups = JsonSerializer.Deserialize("""[{"penColor":"blue","points":[{"x":12.5,"y":8,"time":100,"pressure":0.4}]}]""", InteropJsonContext.Default.ListSignaturePadPointGroup)!;
Check(groups.Count == 1 && groups[0].Points is [{ X: 12.5, Y: 8, Time: 100, Pressure: 0.4 }], "nested signature points");
var json = JsonSerializer.SerializeToElement(groups, InteropJsonContext.Default.IReadOnlyListSignaturePadPointGroup);
Check(json[0].GetProperty("points")[0].GetProperty("pressure").GetDouble() == 0.4, "signature write shape");
var options = JsonSerializer.Deserialize("""{"minWidth":2,"penColor":"red"}""", InteropJsonContext.Default.SignaturePadOptions)!;
Check(JsonSerializer.SerializeToElement(options, InteropJsonContext.Default.SignaturePadOptions).GetProperty("minWidth").GetDouble() == 2, "signature options");

Console.WriteLine("Trimmed JSON smoke checks passed.");

static void Check(bool condition, string name)
{
    if (!condition) throw new InvalidOperationException(name);
}
