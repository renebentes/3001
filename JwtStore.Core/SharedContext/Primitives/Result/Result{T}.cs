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

    /// <summary>
    /// Represents a failure <see cref="Result{TValue}"/> operation with an <see cref="Error"/>
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="error">The <see cref="Error"/></param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified error</returns>
    public static new Result<TValue> Failure(Error error)
        => new(default!, ResultStatus.Error, [error]);

    /// <summary>
    /// Represents a failure <see cref="Result{TValue}"/> operation with a list of errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with a list of errors.</returns>
    public static new Result<TValue> Failure(params Error[] errors)
        => new(default!, ResultStatus.Error, new List<Error>(errors));

    /// <summary>
    /// Represents a failure <see cref="Result{TValue}"/> operation with a list of errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with a list of errors.</returns>

    public static new Result<TValue> Failure(IEnumerable<Error> errors)
        => new(default!, ResultStatus.Error, errors);

    /// <summary>
    /// Represents a invalid <see cref="Result{TValue}"/> operation with a list of validations errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the list of validation errors.</returns>
    public static new Result<TValue> Invalid(IEnumerable<Error> errors)
        => new(default!, ResultStatus.Invalid, errors);

    /// <summary>
    /// Represents a invalid <see cref="Result{TValue}"/> operation with an <see cref="Error"/>
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified validation errors.</returns>
    public static new Result<TValue> Invalid(Error error)
        => new(default!, ResultStatus.Invalid, [error]);

    /// <summary>
    /// Represents a invalid <see cref="Result{TValue}"/> operation with a list of validation errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the list of validation errors.</returns>
    public static new Result<TValue> Invalid(params Error[] errors)
        => new(default!, ResultStatus.Invalid, new List<Error>(errors));

    /// <summary>
    /// Represents a successful <see cref="Result{TValue}"/> operation with the specified value.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="value">The result value.</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the success flag set.</returns>
    public static Result<TValue> Success(TValue value)
        => new(value);

    public static implicit operator Result<TValue>(TValue value)
        => Success(value);
}
