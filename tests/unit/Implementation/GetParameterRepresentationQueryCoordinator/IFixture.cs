namespace Paraminter.Parameters.Representations;

using Moq;

internal interface IFixture<TParameter, TResponse>
{
    public abstract IGetParameterRepresentationQueryCoordinator<TParameter, TResponse> Sut { get; }

    public abstract Mock<IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory>> DelegatingCoordinatorMock { get; }
}
