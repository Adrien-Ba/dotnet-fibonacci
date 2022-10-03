using Microsoft.EntityFrameworkCore;

namespace Leonardo.Tests;

public class UnitTestFibonacci
{
    [Fact]
    public async Task Execute66ShouldReturn8()
    {
        var builder = new DbContextOptionsBuilder<FibonacciDataContext>();
        var dataBaseName = Guid.NewGuid().ToString();
        builder.UseInMemoryDatabase(dataBaseName);
        var options = builder.Options;
        var fibonacciDataContext = new FibonacciDataContext(options);
        await fibonacciDataContext.Database.EnsureCreatedAsync(); 

        var result = await new Fibonacci(fibonacciDataContext).RunAsync(new[] { "6" });
        Assert.Equal(8, result[0]);
    }
}