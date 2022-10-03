// See https://aka.ms/new-console-template for more information

using System;
using System.Diagnostics;
using System.IO;
using Leonardo;
using Microsoft.Extensions.Configuration;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");  

IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
    .Build();    

var applicationName = configuration.GetValue<string>("Application:Name");    
var applicationMessage = configuration.GetValue<string>("Application:Message");   

Console.WriteLine($"Application Name : {applicationName}");    
Console.WriteLine($"Application Message : {applicationMessage}");

var stopwatch = new Stopwatch();

stopwatch.Start();
await using var dataContext = new FibonacciDataContext();

var listOfResults = await new Fibonacci(dataContext).RunAsync(args);

foreach (var listOfResult in listOfResults)
{
    Console.WriteLine($"Result : {listOfResult}");
}
stopwatch.Stop();

Console.WriteLine("time elapsed in seconds : " + stopwatch.Elapsed.Seconds);