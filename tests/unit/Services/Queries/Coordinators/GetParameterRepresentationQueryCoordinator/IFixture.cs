namespace Paraminter.Parameters.Representations.Queries.Coordinators;

using Moq;

using Paraminter.Parameters.Representations.Queries.Factories;
using Paraminter.Queries.Coordinators;

internal interface IFixture<TParameter, TResponse>
{
    public abstract IGetParameterRepresentationQueryCoordinator<TParameter, TResponse> Sut { get; }

    public abstract Mock<IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory>> DelegatingCoordinatorMock { get; }
}
