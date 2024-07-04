namespace Paraminter.Parameters.Representations.GetParameterRepresentationQuery;

using Moq;

internal interface IFixture<TParameter>
    where TParameter : class
{
    public abstract IGetParameterRepresentationQuery<TParameter> Sut { get; }

    public abstract Mock<TParameter> ParameterMock { get; }
}
