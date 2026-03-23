using Soenneker.Blazor.SignaturePads.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blazor.SignaturePads.Tests;

[Collection("Collection")]
public sealed class SignaturePadTests : FixturedUnitTest
{
    private readonly ISignaturePad _blazorlibrary;

    public SignaturePadTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _blazorlibrary = Resolve<ISignaturePad>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
