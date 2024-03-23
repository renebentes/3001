namespace JwtStore.Core.SharedContext.Primitives;
/// <summary>
/// Represents a domain error
/// </summary>
/// <param name="Code">The error code</param>
/// <param name="Message">The error message</param>
public sealed record Error(string Code, string Message);
