namespace JwtStore.Core.SharedContext.Primitives.Result;

/// <summary>
/// Represents a result of operations, with status information and possibly value and errors.
/// </summary>
/// <typeparam name="TValue">The result value type.</typeparam>
public class Result<TValue> : Result
{
    private readonly TValue _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class with specified value.
    /// </summary>
    /// <param name="value">The result value</param>
    protected internal Result(TValue value)
        => _value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class with specified parameters.
    /// </summary>
    /// <param name="value">The result value</param>
    /// <param name="status">The <see cref="ResultStatus"/></param>
    /// <param name="errors">The <see cref="Error"/> collection</param>
    protected internal Result(TValue value, ResultStatus status, IEnumerable<Error> errors)
        : base(status, errors)
        => _value = value;

    /// <summary>
    /// Gets the result value if the result is successful, otherwise throws an exception.
    /// </summary>
    /// <returns>The result value if the result is successful.</returns>
    /// <exception cref="InvalidOperationException"> when <see cref="Result.IsSuccess"/> is false.</exception>
    public TValue Value
        => IsSuccess
        ? _value
        : throw new InvalidOperationException("The value of failure result can't be accessed.");

    public static implicit operator Result<TValue>(TValue value)
        => Success(value);
}
