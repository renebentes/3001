using JwtStore.Core.SharedContext.Primitives.Results;

namespace JwtStore.Core.UnitTests.SharedContext.Primitives.Results;

public class ImplicitOperatorsTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(123)]
    [InlineData("test string")]
    public void CreateSuccessResultFromObject(object input)
    {
        Result<object> result = input;

        result.IsSuccess.Should().BeTrue();
        result.Status.Should().Be(ResultStatus.Ok);
        result.Value.Should().Be(input);
    }
}
