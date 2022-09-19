using System;
using System.Diagnostics;
using Leonardo;

var stopwatch = new Stopwatch();

stopwatch.Start();
var listOfResults = Fibonacci.RunAsync(args);

foreach (var listOfResult in listOfResults)
{
    Console.WriteLine($"Result : {listOfResult}");
}
stopwatch.Stop();

Console.WriteLine("time elapsed in seconds : " + stopwatch.Elapsed.Seconds);

// int Fib(int i)
// {
//     if (i <= 2) return 1;
//     return Fib(i - 1) + Fib(i - 2);
// }  

