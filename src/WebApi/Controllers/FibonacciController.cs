using Leonardo;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class FibonnaciController
{
    [HttpPost(Name = "PostFibo")]
    public async Task<IList<long>> compute([FromServices] ILogger<FibonnaciController> logger, 
        [FromServices] Fibonacci fibonacci, 
        string[] args)
    {
        logger.LogInformation("youhou");
        return await fibonacci.RunAsync(args);
    }
}