using Flunt.Notifications;
using Flunt.Validations;
using JwtStore.Core.SharedContext.Primitives;

namespace JwtStore.UseCases.Extensions;

public static class FluntExtensions
{
    public static IEnumerable<Error> AsErrors(this Contract<Notification> contract)
    {
        var errors = new List<Error>();

        foreach (var notification in contract.Notifications)
        {
            errors.Add(new Error(notification.Key, notification.Message));
        }

        return errors;
    }
}
