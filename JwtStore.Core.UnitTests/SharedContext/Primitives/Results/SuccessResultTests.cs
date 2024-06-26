using JwtStore.Core.SharedContext.Primitives.Results;

namespace JwtStore.Core.UnitTests.SharedContext.Primitives.Results;

public class SuccessResultTests
{
    [Fact]
    public void CreateGenericSuccessResult()
    {
        var result = Result.Success<object>(new());

        result.IsSuccess.Should().BeTrue();

        result.Status.Should().Be(ResultStatus.Ok);
    }

    [Fact]
    public void CreateSuccessResult()
    {
        var result = Result.Success();

        result.IsSuccess.Should().BeTrue();

        result.Status.Should().Be(ResultStatus.Ok);
    }

    [Fact]
    public void StronglyTypedIntSuccessResultHasIntValue()
    {
        var expectedInt = 10;
        var result = Result.Success(expectedInt);

        result.Value.Should().Be(expectedInt);
        result.Value.Should().BeOfType(typeof(int));
    }
}
