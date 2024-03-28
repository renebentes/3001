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
    protected Result(TValue value)
        => _value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class with specified parameters.
    /// </summary>
    /// <param name="value">The result value</param>
    /// <param name="status">The <see cref="ResultStatus"/></param>
    /// <param name="errors">The <see cref="Error"/> collection</param>
    protected Result(TValue value, ResultStatus status, IEnumerable<Error> errors)
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

    /// <summary>
    /// Represents a successful <see cref="Result{TValue}"/> operation with the specified value.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="value">The result value.</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the success flag set.</returns>
    public static Result<TValue> Success(TValue value)
        => new(value);

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="error"></param>
    /// <returns></returns>
    public static new Result<TValue> Failure(Error error)
        => new(default!, ResultStatus.Error, [error]);

    public static new Result<TValue> Failure(params Error[] errors)
        => new(default!, ResultStatus.Error, new List<Error>(errors));

    public static new Result<TValue> Failure(IEnumerable<Error> errors)
        => new(default!, ResultStatus.Error, errors);
}
