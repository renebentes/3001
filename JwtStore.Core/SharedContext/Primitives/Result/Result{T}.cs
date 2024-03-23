namespace JwtStore.Core.SharedContext.Primitives.Result;

/// <summary>
/// Represents a result of operations, with status information and possibly a value and an error.
/// </summary>
/// <typeparam name="TValue">The result value type.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value)
        => _value = value;

    protected internal Result(TValue value, IEnumerable<Error> errors)
        : base(errors)
        => _value = value;

    /// <summary>
    /// Gets the result value if the result is successful, otherwise throws an exception.
    /// </summary>
    /// <returns>The result value if the result is successful.</returns>
    /// <exception cref="InvalidOperationException"> when <see cref="Result.IsFailure"/> is true.</exception>
    public TValue Value
        => IsSuccess
        ? _value
        : throw new InvalidOperationException("The value of failure result can't be accessed.");

    public static implicit operator Result<TValue>(TValue value)
        => Success(value);
}
