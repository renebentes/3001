using FluentAssertions;

namespace JwtStore.UseCases.UnitTests.Results;

public class FluntExtensionsTests
{
    [Fact]
    public void ToResulShouldReturnAnInvalidResult()
    {
        var complexObject = new ComplexObject();
        var result = complexObject.ToResult();

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    [Fact]
    public void ToResulStronglyTypedShouldReturnAnInvalidResult()
    {
        var complexObject = new ComplexObject();
        var result = complexObject.ToResult<bool>();

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Invalid);
    }

    private class ComplexObject : Notifiable<Notification>
    {
        public ComplexObject()
            => AddNotification(new Notification("test", "notification test message"));
    }
}
