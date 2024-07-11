namespace Paraminter.Parameters.Representations.Queries.Factories;

using System;

/// <inheritdoc cref="IGetParameterRepresentationQueryFactory"/>
public sealed class GetParameterRepresentationQueryFactory
    : IGetParameterRepresentationQueryFactory
{
    /// <summary>Instantiates a <see cref="GetParameterRepresentationQueryFactory"/>, handling creation of <see cref="IGetParameterRepresentationQuery{TParameter}"/>.</summary>
    public GetParameterRepresentationQueryFactory() { }

    IGetParameterRepresentationQuery<TParameter> IGetParameterRepresentationQueryFactory.Create<TParameter>(
        TParameter parameter)
    {
        if (parameter is null)
        {
            throw new ArgumentNullException(nameof(parameter));
        }

        return new GetParameterRepresentationQuery<TParameter>(parameter);
    }

    private sealed class GetParameterRepresentationQuery<TParameter>
        : IGetParameterRepresentationQuery<TParameter>
    {
        private readonly TParameter Parameter;

        public GetParameterRepresentationQuery(
            TParameter parameter)
        {
            Parameter = parameter;
        }

        TParameter IGetParameterRepresentationQuery<TParameter>.Parameter => Parameter;
    }
}
