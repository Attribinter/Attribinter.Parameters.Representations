namespace Paraminter.Parameters.Representations;

/// <summary>Handles creation of <see cref="IGetParameterRepresentationQuery{TParameter}"/>.</summary>
public interface IGetParameterRepresentationQueryFactory
{
    /// <summary>Creates a <see cref="IGetParameterRepresentationQuery{TParameter}"/>.</summary>
    /// <typeparam name="TParameter">The type of the represented parameter.</typeparam>
    /// <param name="parameter">The represented parameter.</param>
    /// <returns>The created <see cref="IGetParameterRepresentationQuery{TParameter}"/>.</returns>
    public abstract IGetParameterRepresentationQuery<TParameter> Create<TParameter>(
        TParameter parameter);
}
