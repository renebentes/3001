namespace JwtStore.UseCases.Messaging;

/// <summary>
/// Defines a handler for a request
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : IResquest<TResponse>
{
}
