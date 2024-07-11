namespace Paraminter.Parameters.Representations.Queries.Coordinators;

using Moq;

using Paraminter.Parameters.Representations.Queries.Factories;
using Paraminter.Queries.Coordinators;

internal static class FixtureFactory
{
    public static IFixture<TParameter, TResponse> Create<TParameter, TResponse>()
    {
        Mock<IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory>> delegatingCoordinatorMock = new();

        GetParameterRepresentationQueryCoordinator<TParameter, TResponse> sut = new(delegatingCoordinatorMock.Object);

        return new Fixture<TParameter, TResponse>(sut, delegatingCoordinatorMock);
    }

    private sealed class Fixture<TParameter, TResponse>
        : IFixture<TParameter, TResponse>
    {
        private readonly IGetParameterRepresentationQueryCoordinator<TParameter, TResponse> Sut;

        private readonly Mock<IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory>> DelegatingCoordinatorMock;

        public Fixture(
            IGetParameterRepresentationQueryCoordinator<TParameter, TResponse> sut,
            Mock<IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory>> delegatingCoordinatorMock)
        {
            Sut = sut;

            DelegatingCoordinatorMock = delegatingCoordinatorMock;
        }

        IGetParameterRepresentationQueryCoordinator<TParameter, TResponse> IFixture<TParameter, TResponse>.Sut => Sut;

        Mock<IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory>> IFixture<TParameter, TResponse>.DelegatingCoordinatorMock => DelegatingCoordinatorMock;
    }
}
