namespace Paraminter.Parameters.Representations.Queries.Coordinators;

using Moq;

using Paraminter.Parameters.Representations.Queries.Factories;
using Paraminter.Queries.Coordinators;

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
    public void ValidArguments_HandlesQuery()
    {
        var fixture = FixtureFactory.Create<object, object>();

        var parameter = Mock.Of<object>();

        var response = Mock.Of<object>();

        fixture.DelegatingCoordinatorMock.Setup(CoordinatorExpression<object, object>(parameter)).Returns(response);

        var result = Target(fixture, parameter);

        Assert.Same(response, result);

        fixture.DelegatingCoordinatorMock.Verify(CoordinatorExpression<object, object>(parameter), Times.Once);
    }

    private static Expression<Func<IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory>, TResponse>> CoordinatorExpression<TParameter, TResponse>(
        TParameter parameter)
    {
        return (coordinator) => coordinator.Handle(It.Is(MatchQueryCreationDelegate(parameter)));
    }

    private static Expression<Func<DCreateQueryThroughFactory<IGetParameterRepresentationQueryFactory, IGetParameterRepresentationQuery<TParameter>>, bool>> MatchQueryCreationDelegate<TParameter>(
        TParameter parameter)
    {
        return (queryCreationDelegate) => VerifyQueryCreationDelegate(queryCreationDelegate, parameter);
    }

    private static bool VerifyQueryCreationDelegate<TParameter>(
        DCreateQueryThroughFactory<IGetParameterRepresentationQueryFactory, IGetParameterRepresentationQuery<TParameter>> queryCreationDelegate,
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
