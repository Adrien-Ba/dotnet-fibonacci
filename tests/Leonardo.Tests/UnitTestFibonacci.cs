namespace Leonardo.Tests;

public class UnitTestFibonacci
{
    [Fact]
    public void RunAsyncShouldRetrun8()
    {
        var result = Fibonacci.RunAsync(new[] { "6" });
        Assert.Equal(8,  result[0]);
    }
}