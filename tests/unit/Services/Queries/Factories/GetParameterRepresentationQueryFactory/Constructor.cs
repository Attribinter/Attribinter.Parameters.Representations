namespace Paraminter.Parameters.Representations.Queries.Factories;

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
