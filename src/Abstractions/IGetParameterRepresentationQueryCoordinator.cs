namespace Paraminter.Parameters.Representations;

/// <summary>Coordinates creation and handling of <see cref="IGetParameterRepresentationQuery{TParameter}"/>.</summary>
/// <typeparam name="TParameter">The type of the represented parameter.</typeparam>
/// <typeparam name="TResponse">The type representing the response of the query.</typeparam>
public interface IGetParameterRepresentationQueryCoordinator<in TParameter, out TResponse>
{
    /// <summary>Creates and handles a <see cref="IGetParameterRepresentationQuery{TParameter}"/>.</summary>
    /// <param name="parameter">The represented parameter.</param>
    /// <returns>The response of the query.</returns>
    public abstract TResponse Handle(
        TParameter parameter);
}
