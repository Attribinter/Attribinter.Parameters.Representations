namespace Paraminter.Parameters.Representations;

using Moq;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullDelegatingCoordinator_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsCoordinator()
    {
        var result = Target(Mock.Of<IQueryCoordinator<IGetParameterRepresentationQuery<object>, object, IGetParameterRepresentationQueryFactory>>());

        Assert.NotNull(result);
    }

    private static GetParameterRepresentationQueryCoordinator<TParameter, TResponse> Target<TParameter, TResponse>(
        IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory> delegatingCoordinator)
    {
        return new GetParameterRepresentationQueryCoordinator<TParameter, TResponse>(delegatingCoordinator);
    }
}
