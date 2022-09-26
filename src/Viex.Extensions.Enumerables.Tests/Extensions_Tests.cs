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
}
