namespace JwtStore.Core.SharedContext.Primitives.Result;

/// <summary>
/// Represents a result of operations, with status information and possibly an error.
/// </summary>
public class Result
{
    protected Result()
    {
    }

    protected Result(IEnumerable<Error> errors)
        => Errors = errors;

    public IEnumerable<Error> Errors { get; } = [];

    public bool IsFailure => Errors.Any();

    public bool IsSuccess => !IsFailure;

    /// <summary>
    /// Returns a failure <see cref="Result"/> with the specified error.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <returns>A new instance of <see cref="Result"/> with the specified error and failure flag set.</returns>
    public static Result Failure(Error error)
        => new([error]);

    /// <summary>
    /// Returns a failure <see cref="Result"/> with a error list.
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static Result Failure(IEnumerable<Error> errors)
        => new(errors);

    public static Result Failure(params Error[] errors)
        => new(new List<Error>(errors));

    public static Result<TValue> Failure<TValue>(Error error)
        => new(default!, [error]);

    public static Result<TValue> Failure<TValue>(params Error[] errors)
        => new(default!, new List<Error>(errors));

    public static Result<TValue> Failure<TValue>(IEnumerable<Error> errors)
        => new(default!, errors);

    public static Result<TValue> Success<TValue>(TValue value)
        => new(value);

    /// <summary>
    /// Returns a success <see cref="Result"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Result"/> with the success flag set.</returns>
    public static Result Success()
        => new();
}
