namespace JwtStore.UseCases.Messaging;

/// <summary>
/// Represents a command with a response
/// </summary>
/// <typeparam name="TResponse">Response type</typeparam>
public interface ICommand<out TResponse>
{
}
