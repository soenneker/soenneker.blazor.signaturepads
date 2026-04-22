using Soenneker.Blazor.SignaturePads.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.SignaturePads.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SignaturePadTests : HostedUnitTest
{
    private readonly ISignaturePad _blazorlibrary;

    public SignaturePadTests(Host host) : base(host)
    {
        _blazorlibrary = Resolve<ISignaturePad>(true);
    }

    [Test]
    public void Default()
    {

    }
}
