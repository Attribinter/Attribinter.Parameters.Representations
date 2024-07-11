namespace Paraminter.Parameters.Representations.Queries.Coordinators;

using Paraminter.Parameters.Representations.Queries.Factories;
using Paraminter.Queries.Coordinators;

using System;

/// <inheritdoc cref="IGetParameterRepresentationQueryCoordinator{TParameter, TResponse}"/>
public sealed class GetParameterRepresentationQueryCoordinator<TParameter, TResponse>
    : IGetParameterRepresentationQueryCoordinator<TParameter, TResponse>
{
    private readonly IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory> DelegatingCoordinator;

    /// <summary>Instantiates a <see cref="GetParameterRepresentationQueryCoordinator{TParameter, TResponse}"/>, coordinating creation of handling of <see cref="IGetParameterRepresentationQuery{TParameter}"/>.</summary>
    /// <param name="delegatingCoordinator">Coordinates creation and handling of queries.</param>
    public GetParameterRepresentationQueryCoordinator(
        IQueryCoordinator<IGetParameterRepresentationQuery<TParameter>, TResponse, IGetParameterRepresentationQueryFactory> delegatingCoordinator)
    {
        DelegatingCoordinator = delegatingCoordinator ?? throw new ArgumentNullException(nameof(delegatingCoordinator));
    }

    TResponse IGetParameterRepresentationQueryCoordinator<TParameter, TResponse>.Handle(
        TParameter parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }

        return DelegatingCoordinator.Handle(createQuery);

        IGetParameterRepresentationQuery<TParameter> createQuery(
            IGetParameterRepresentationQueryFactory factory)
        {
            return factory.Create(parameter);
        }
    }
}
