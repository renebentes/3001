namespace JwtStore.UseCases.Messaging;

/// <summary>
/// Defines a handler for a command
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface ICommandHandle<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}
