namespace JwtStore.Core.SharedContext.Primitives;

/// <summary>
/// Represents a concrete domain error
/// </summary>
public sealed record Error(string Code, string Message)
{
    /// <summary>
    /// Gets the empty error instance.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);
}
