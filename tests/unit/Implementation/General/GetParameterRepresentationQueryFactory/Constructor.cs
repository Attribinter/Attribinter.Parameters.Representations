namespace Paraminter.Parameters.Representations;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static GetParameterRepresentationQueryFactory Target() => new();
}
