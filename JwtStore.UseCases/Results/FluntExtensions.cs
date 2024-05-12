using JwtStore.Core.SharedContext.Primitives;

namespace JwtStore.UseCases.Results;

public static class FluntExtensions
{
    /// <summary>
    /// Converts a <see cref="Notifiable{T}" objecta in an invalid <see cref="Result"/>/>
    /// </summary>
    /// <param name="notifiable">The <see cref="Notifiable{T}"/> object to convert</param>
    /// <returns>An instance of an invalid <see cref="Result"/></returns>
    public static Result ToResult(this Notifiable<Notification> notifiable)
        => Result.Invalid([.. notifiable.Notifications.AsErrors()]);

    /// <summary>
    /// Converts a <see cref="Notifiable{T}" objecta in an invalid <see cref="Result{TValue}"/>/>
    /// </summary>
    /// <returns>An invalid <see cref="Result{TValue}"/></returns>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="notifiable">The <see cref="Notifiable{T}"/> object to convert</param>
    /// <returns>An instance of an invalid <see cref="Result{TValue}"/></returns>
    public static Result<TValue> ToResult<TValue>(this Notifiable<Notification> notifiable)
        => Result.Invalid<TValue>([.. notifiable.Notifications.AsErrors()]);

    /// <summary>
    /// Creates a collection of <see cref="Error"/> elements
    /// </summary>
    /// <param name="notifications">Collection of <see cref="Notification"/> elements</param>
    /// <returns>An <see cref="IEnumerable{T}"/> that contains an collection of <see cref="Error"/> elements.</returns>
    private static IEnumerable<Error> AsErrors(this IReadOnlyCollection<Notification> notifications)
    {
        IList<Error> errors = [];

        foreach (var notification in notifications)
        {
            errors.Add(new Error(notification.Key, notification.Message));
        }

        return errors;
    }
}
