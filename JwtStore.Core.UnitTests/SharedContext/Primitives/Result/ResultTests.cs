using FluentAssertions;
using JwtStore.Core.SharedContext.Primitives;
using JwtStore.Core.SharedContext.Primitives.Result;

namespace JwtStore.Core.UnitTests.SharedContext.Primitives;

public class ResultTests
{

    [Fact]
    public void InitializesFailureResult()
    {
        var error = new Error("error", "error message");
        var result = Result.Failure(error);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Error);
        result.Errors.Should().ContainEquivalentOf(error);
    }

    [Fact]
    public void InitializesFailureResultWithListOfErrors()
    {
        var errors = new List<Error>{
            new("error1", "error message"),
            new("error2", "error message")
        };

        var result = Result.Failure(errors);

        result.IsSuccess.Should()
            .BeFalse();
        result.Status.Should().Be(ResultStatus.Error);

        foreach (var error in errors)
        {
            result.Errors.Should().ContainEquivalentOf(error);
        }
    }

    [Fact]
    public void InitializesFailureResultWithMultiplesErrors()
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
    public void InitializesSuccessResult()
    {
        var result = Result.Success();

        result.IsSuccess.Should()
            .BeTrue();
        result.Status.Should().Be(ResultStatus.Ok);
    }
}
