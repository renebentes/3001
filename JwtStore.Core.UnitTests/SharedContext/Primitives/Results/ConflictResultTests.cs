using JwtStore.Core.SharedContext.Primitives;
using JwtStore.Core.SharedContext.Primitives.Results;

namespace JwtStore.Core.UnitTests.SharedContext.Primitives.Results;

public class ConflictResultTests
{
    [Fact]
    public void CreateConflictResultWithConflict()
    {
        var error = new Error("conflict", "conflict message");
        var result = Result.Conflict(error);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Conflict);
        result.Errors.Should().ContainEquivalentOf(error);
    }

    [Fact]
    public void CreateConflictResultWithListOfConflicts()
    {
        var errors = new List<Error>{
            new("conflict1", "conflict message"),
            new("conflict2", "conflict message")
        };

        var result = Result.Conflict([.. errors]);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Conflict);

        foreach (var error in errors)
        {
            result.Errors.Should().ContainEquivalentOf(error);
        }
    }

    [Fact]
    public void CreateConflictResultWithMultiplesConflicts()
    {
        var errors = new Error[]{
            new("conflict1", "conflict message"),
            new("conflict2", "conflict message")
        };

        var result = Result.Conflict(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Conflict);

        foreach (var error in errors)
        {
            result.Errors.Should().ContainEquivalentOf(error);
        }
    }

    [Fact]
    public void CreateStronglyTypeConflictResultWithConflict()
    {
        var error = new Error("conflict", "conflict message");
        var result = Result.Conflict<object>(error);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Conflict);
        result.Errors.Should().ContainEquivalentOf(error);
    }

    [Fact]
    public void CreateStronglyTypeConflictResultWithListOfConflicts()
    {
        var errors = new List<Error>{
            new("conflict1", "conflict message"),
            new("conflict2", "conflict message")
        };

        var result = Result.Conflict<int>([.. errors]);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Conflict);

        foreach (var error in errors)
        {
            result.Errors.Should().ContainEquivalentOf(error);
        }
    }

    [Fact]
    public void CreateStronglyTypeConflictResultWithMultiplesConflicts()
    {
        var errors = new Error[]{
            new("conflict1", "conflict message"),
            new("conflict2", "conflict message")
        };

        var result = Result.Conflict<string>(errors);

        result.IsSuccess.Should().BeFalse();
        result.Status.Should().Be(ResultStatus.Conflict);

        foreach (var error in errors)
        {
            result.Errors.Should().ContainEquivalentOf(error);
        }
    }
}
