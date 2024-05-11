using JwtStore.Core.SharedContext.Primitives;
using JwtStore.Core.SharedContext.Primitives.Results;

namespace JwtStore.Core.UnitTests.SharedContext.Primitives.Results;

public class FailureResultTests
{
    [Fact]
    public void CreateFailureResultWithError()
    {
        var error = new Error("error", "error message");
        var result = Result.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Error);
        result.Errors.Should().ContainEquivalentOf(error);
    }

    [Fact]
    public void CreateFailureResultWithListOfErrors()
    {
        var errors = new List<Error>{
            new("error1", "error message"),
            new("error2", "error message")
        };

        var result = Result.Failure(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Error);

        foreach (var error in errors)
        {
            result.Errors.Should().ContainEquivalentOf(error);
        }
    }

    [Fact]
    public void CreateFailureResultWithMultiplesErrors()
    {
        var errors = new Error[]{
            new("error1", "error message"),
            new("error2", "error message")
        };

        var result = Result.Failure(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Error);

        foreach (var error in errors)
        {
            result.Errors.Should().ContainEquivalentOf(error);
        }
    }

    [Fact]
    public void CreateStronglyTypedIntFailureResult()
    {
        var error = new Error("error", "error message");
        var result = Result.Failure<int>(error);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Error);
        result.Errors.Should().ContainEquivalentOf(error);
    }

    [Fact]
    public void GetsValueThrowsInvalidOperationExceptionOnFailureResult()
    {
        var error = new Error("error", "error message");
        var result = Result.Failure<int>(error);

        result.Invoking(action => action.Value).Should().Throw<InvalidOperationException>();
    }
}
