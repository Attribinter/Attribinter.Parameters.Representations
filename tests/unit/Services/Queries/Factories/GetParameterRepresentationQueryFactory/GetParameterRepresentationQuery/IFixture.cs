namespace Paraminter.Parameters.Representations.Queries.Factories.GetParameterRepresentationQuery;

using Moq;

internal interface IFixture<TParameter>
    where TParameter : class
{
    public abstract IGetParameterRepresentationQuery<TParameter> Sut { get; }

    public abstract Mock<TParameter> ParameterMock { get; }
}
