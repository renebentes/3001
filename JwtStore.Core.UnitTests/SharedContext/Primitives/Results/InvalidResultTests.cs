using JwtStore.Core.SharedContext.Primitives;
using JwtStore.Core.SharedContext.Primitives.Results;

namespace JwtStore.Core.UnitTests.SharedContext.Primitives.Results;

public class InvalidResultTests
{
    [Fact]
    public void CreateInvalidResultShouldHaveInvalidStatus()
    {
        var result = Result.Invalid(new Error("invalid", "invalid error message"));

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public void CreateInvalidResultWithListOfInvalidErrorsShouldHaveInvalidStatus()
    {
        var errors = new List<Error>{
            new("invaliderror1", "invalid error message"),
            new("invaliderror2", "invalid error message")
        };

        var result = Result.Invalid(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public void CreateInvalidResultWithMultipleInvalidErrorsShouldHaveInvalidStatus()
    {
        var errors = new Error[]{
            new("invaliderror1", "invalid error message"),
            new("invaliderror2", "invalid error message")
        };

        var result = Result.Invalid(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public void CreateStronglyTypedInvalidResultMultipleInvalidErrorsShouldHaveInvalidStatus()
    {
        var errors = new Error[]{
            new("invaliderror1", "invalid error message"),
            new("invaliderror2", "invalid error message")
        };

        var result = Result.Invalid<object>(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public void CreateStronglyTypedInvalidResultShouldHaveInvalidStatus()
    {
        var result = Result.Invalid<string>(new Error("invalid", "invalid error message"));

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public void CreateStronglyTypedInvalidResultWithListOfInvalidErrorsShouldHaveInvalidStatus()
    {
        var errors = new List<Error>{
            new("invaliderror1", "invalid error message"),
            new("invaliderror2", "invalid error message")
        };

        var result = Result.Invalid<bool>(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }
}
