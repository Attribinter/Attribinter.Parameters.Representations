namespace Paraminter.Parameters.Representations;

using Paraminter.Queries;

/// <summary>Represents a query for a parameter representation.</summary>
/// <typeparam name="TParameter">The type of the represented parameter.</typeparam>
public interface IGetParameterRepresentationQuery<out TParameter>
    : IQuery
{
    /// <summary>The represented parameter.</summary>
    public abstract TParameter Parameter { get; }
}
