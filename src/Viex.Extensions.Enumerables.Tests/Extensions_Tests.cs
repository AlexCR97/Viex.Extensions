namespace Viex.Extensions.Enumerables.Tests;

public class Extensions_Tests
{
    [Fact]
    public void EmptyShouldReturnTrue()
    {
        var source = Enumerable.Empty<int>();
        Assert.True(source.Empty() == true, "Source must be empty");
    }

    [Fact]
    public void EmptyShouldReturnFalse()
    {
        var source = new int[] { 1, 2, 3 };
        Assert.True(source.Empty() == false, "Source must NOT be empty");
    }

    [Theory]
    [InlineData(new string[] { "This", "Is", "The", "Output" }, "ThisIsTheOutput")]
    public void JoinStringShouldSucceed(string[] input, string expectedOutput)
    {
        var realOutput = input.JoinString();
        Assert.True(realOutput == expectedOutput, @$"Output should be ""{expectedOutput}""");
    }

    [Theory]
    [InlineData(new string[] { "api", "users", "25" }, "api/users/25")]
    public void JoinStringWithCharSeparatorShouldSucceed(string[] input, string expectedOutput)
    {
        var realOutput = input.JoinString('/');
        Assert.True(realOutput == expectedOutput, @$"Output should be ""{expectedOutput}""");
    }

    [Theory]
    [InlineData(new string[] { "api", "users", "25" }, "api/users/25")]
    public void JoinStringWithStringSeparatorShouldSucceed(string[] input, string expectedOutput)
    {
        var realOutput = input.JoinString("/");
        Assert.True(realOutput == expectedOutput, @$"Output should be ""{expectedOutput}""");
    }
}
