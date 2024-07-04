namespace Paraminter.Parameters.Representations;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        GetParameterRepresentationQueryFactory sut = new();

        return new Fixture(sut);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly IGetParameterRepresentationQueryFactory Sut;

        public Fixture(
            IGetParameterRepresentationQueryFactory sut)
        {
            Sut = sut;
        }

        IGetParameterRepresentationQueryFactory IFixture.Sut => Sut;
    }
}
