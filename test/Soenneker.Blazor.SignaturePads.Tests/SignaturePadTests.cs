using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.SignaturePads.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SignaturePadTests : HostedUnitTest
{
    public SignaturePadTests(Host host) : base(host)
    {

    }

    [Test]
    public void Default()
    {

    }
}
