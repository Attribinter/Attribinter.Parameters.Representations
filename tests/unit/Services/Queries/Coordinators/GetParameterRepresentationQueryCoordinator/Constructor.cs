namespace Paraminter.Parameters.Representations.Queries.Coordinators;

using Moq;

using Paraminter.Parameters.Representations.Queries.Factories;
using Paraminter.Queries.Coordinators;

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
