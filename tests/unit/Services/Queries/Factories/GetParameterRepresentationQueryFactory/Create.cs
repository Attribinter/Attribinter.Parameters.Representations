namespace Paraminter.Parameters.Representations.Queries.Factories;

using Moq;

using System;

using Xunit;

public sealed class Create()
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullParameter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidParameter_ReturnsQuery()
    {
        var result = Target(Mock.Of<object>());

        Assert.NotNull(result);
    }

    private IGetParameterRepresentationQuery<TParameter> Target<TParameter>(
        TParameter parameter)
    {
        return Fixture.Sut.Create(parameter);
    }
}
