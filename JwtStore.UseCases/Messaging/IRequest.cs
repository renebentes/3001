namespace JwtStore.UseCases.Messaging;

/// <summary>
/// Represents a request with a response
/// </summary>
/// <typeparam name="TResponse">Response type</typeparam>
public interface IRequest<out TResponse>
{
}
