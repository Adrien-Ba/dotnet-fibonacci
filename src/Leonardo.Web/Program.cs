using Leonardo;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/Fibonnaci", async () =>
{
    await using var dataContext = new FibonacciDataContext();
    return new Fibonacci(dataContext).RunAsync(new[] { "43", "46" });
});

app.Run();