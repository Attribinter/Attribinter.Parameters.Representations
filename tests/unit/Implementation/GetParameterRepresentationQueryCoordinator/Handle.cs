namespace Paraminter.Parameters.Representations;

using Moq;

using System;
using System.Linq.Expressions;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullParameter_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_HandlesCommand()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var parameter = Mock.Of<object>();

        Target(fixture, parameter);

        fixture.DelegatingCoordinatorMock.Verify((coordinator) => coordinator.Handle(It.Is(MatchCommandCreationDelegate(parameter))), Times.Once);
    }

    private static Expression<Func<DCreateQuery<IGetParameterRepresentationQuery<TParameter>, IGetParameterRepresentationQueryFactory>, bool>> MatchCommandCreationDelegate<TParameter>(
        TParameter parameter)
    {
        return (commandCreationDelegate) => VerifyCommandCreationDelegate(commandCreationDelegate, parameter);
    }

    private static bool VerifyCommandCreationDelegate<TParameter>(
        DCreateQuery<IGetParameterRepresentationQuery<TParameter>, IGetParameterRepresentationQueryFactory> queryCreationDelegate,
        TParameter parameter)
    {
        var query = Mock.Of<IGetParameterRepresentationQuery<TParameter>>();

        Mock<IGetParameterRepresentationQueryFactory> queryFactoryMock = new();

        queryFactoryMock.Setup((factory) => factory.Create(parameter)).Returns(query);

        var result = queryCreationDelegate(queryFactoryMock.Object);

        return ReferenceEquals(result, query);
    }

    private static TResponse Target<TParameter, TResponse>(
        IFixture<TParameter, TResponse> fixture,
        TParameter parameter)
    {
        return fixture.Sut.Handle(parameter);
    }
}
