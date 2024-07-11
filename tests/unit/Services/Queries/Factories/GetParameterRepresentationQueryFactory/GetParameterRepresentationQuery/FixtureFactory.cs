namespace Paraminter.Parameters.Representations.Queries.Factories.GetParameterRepresentationQuery;

using Moq;

internal static class FixtureFactory
{
    public static IFixture<TParameter> Create<TParameter>()
        where TParameter : class
    {
        Mock<TParameter> parameterMock = new();

        IGetParameterRepresentationQueryFactory factory = new GetParameterRepresentationQueryFactory();

        var sut = factory.Create(parameterMock.Object);

        return new Fixture<TParameter>(sut, parameterMock);
    }

    private sealed class Fixture<TParameter>
        : IFixture<TParameter>
        where TParameter : class
    {
        private readonly IGetParameterRepresentationQuery<TParameter> Sut;

        private readonly Mock<TParameter> ParameterMock;

        public Fixture(
            IGetParameterRepresentationQuery<TParameter> sut,
            Mock<TParameter> parameterMock)
        {
            Sut = sut;

            ParameterMock = parameterMock;
        }

        IGetParameterRepresentationQuery<TParameter> IFixture<TParameter>.Sut => Sut;

        Mock<TParameter> IFixture<TParameter>.ParameterMock => ParameterMock;
    }
}
