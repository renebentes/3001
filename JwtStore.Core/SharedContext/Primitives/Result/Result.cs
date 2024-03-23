namespace JwtStore.Core.SharedContext.Primitives.Result;

/// <summary>
/// Represents a result of operations, with status information and possibly errors.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    protected Result()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with a specified status and a collection of errors.
    /// </summary>
    /// <param name="status">The <see cref="ResultStatus"/></param>
    /// <param name="errors">The <see cref="Error"/> collection</param>
    protected Result(ResultStatus status, IEnumerable<Error> errors)
    {
        Status = status;
        Errors = errors;
    }

    /// <summary>
    /// Gets the collection of errors
    /// </summary>
    public IEnumerable<Error> Errors { get; } = [];

    public bool IsSuccess => Status == ResultStatus.Ok;

    public ResultStatus Status { get; } = ResultStatus.Ok;

    /// <summary>
    /// Represents a failure <see cref="Result"/> operation with an <see cref="Error"/>
    /// </summary>
    /// <param name="error">The <see cref="Error"/></param>
    /// <returns>A new instance of <see cref="Result"/> with the specified error</returns>
    public static Result Failure(Error error)
        => new(ResultStatus.Error, [error]);

    /// <summary>
    /// Represents a failure <see cref="Result"/> operation with a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors</param>
    /// <returns>A new instance of <see cref="Result"/> with the list of errors.</returns>
    public static Result Failure(IEnumerable<Error> errors)
        => new(ResultStatus.Error, errors);

    /// <summary>
    /// Represents a failure <see cref="Result"/> operation with a list of errors.
    /// </summary>
    /// <param name="errors">The list of errors</param>
    /// <returns>A new instance of <see cref="Result"/> with the list of errors.</returns>
    public static Result Failure(params Error[] errors)
        => new(ResultStatus.Error, new List<Error>(errors));

    /// <summary>
    /// Represents a failure <see cref="Result{TValue}"/> operation with an <see cref="Error"/>
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="error">The <see cref="Error"/></param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified error</returns>
    public static Result<TValue> Failure<TValue>(Error error)
        => new(default!, ResultStatus.Error, [error]);

    /// <summary>
    /// Represents a failure <see cref="Result{TValue}"/> operation with a list of errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with a list of errors.</returns>
    public static Result<TValue> Failure<TValue>(params Error[] errors)
        => new(default!, ResultStatus.Error, new List<Error>(errors));

    /// <summary>
    /// Represents a failure <see cref="Result{TValue}"/> operation with a list of errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with a list of errors.</returns>
    public static Result<TValue> Failure<TValue>(IEnumerable<Error> errors)
        => new(default!, ResultStatus.Error, errors);

    /// <summary>
    /// Represents a invalid <see cref="Result"/> operation with a list of errors.
    /// </summary>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result"/> with the list of validation errors.</returns>
    public static Result Invalid(IEnumerable<Error> errors)
        => new(ResultStatus.Invalid, errors);

    /// <summary>
    /// Represents a invalid <see cref="Result"/> operation with an <see cref="Error"/>
    /// </summary>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result"/> with the specified validation errors.</returns>
    public static Result Invalid(Error error)
        => new(ResultStatus.Invalid, [error]);

    /// <summary>
    /// Represents a invalid <see cref="Result"/> operation with a list of errors.
    /// </summary>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result"/> with the list of validation errors.</returns>
    public static Result Invalid(params Error[] errors)
        => new(ResultStatus.Invalid, new List<Error>(errors));

    /// <summary>
    /// Represents a invalid <see cref="Result{TValue}"/> operation with a list of validations errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the list of validation errors.</returns>
    public static Result<TValue> Invalid<TValue>(IEnumerable<Error> errors)
        => new(default!, ResultStatus.Invalid, errors);

    /// <summary>
    /// Represents a invalid <see cref="Result{TValue}"/> operation with an <see cref="Error"/>
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the specified validation errors.</returns>
    public static Result<TValue> Invalid<TValue>(Error error)
        => new(default!, ResultStatus.Invalid, [error]);

    /// <summary>
    /// Represents a invalid <see cref="Result{TValue}"/> operation with a list of validation errors.
    /// </summary>
    /// <typeparam name="TValue">The result type.</typeparam>
    /// <param name="errors">The list of validation errors</param>
    /// <returns>A new instance of <see cref="Result{TValue}"/> with the list of validation errors.</returns>
    public static Result<TValue> Invalid<TValue>(params Error[] errors)
        => new(default!, ResultStatus.Invalid, new List<Error>(errors));

    /// <summary>
    /// Represents a successful <see cref="Result"/> operation
    /// </summary>
    /// <returns>A <see cref="Result"/></returns>
    public static Result Success()
        => new();
}
