using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leonardo;

public static class Fibonacci
{
    public static int Run(int i)
    {
        if (i <= 2) return 1;
        return Run(i - 1) + Run(i - 2);
    }    
    
    public static List<int> RunAsync(string[] args)    {          
        var tasks = new List<Task<int>>();
        foreach (var arg in args)
        {
            var result = Task.Run(() => Fibonacci.Run(Convert.ToInt32(arg)));
            tasks.Add(result);
        }

        Task.WaitAll(tasks.ToArray());
        return tasks.Select(t=>t.Result).ToList();
    }     
}