using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Benchmarks.Config;
using Benchmarks.Interviews.Chris;
using Benchmarks.Interviews.Hanu;
using Benchmarks.Interviews.Naive;
using Benchmarks.Interviews.Shared;
using Benchmarks.Interviews.Validators;

namespace Benchmarks.Interviews;

[Config(typeof(BenchmarkConfig))]
public class InterviewBenchmark
{
    private List<LogEntry> Day1Logs { get; } = [];
    private List<LogEntry> Day2Logs { get; } = [];

    [GlobalSetup]
    public void Setup()
    {
        var rng = new Random((int)DateTime.Now.Ticks);

        var c = 0;
        while (c < 5000)
        {
            Day1Logs.Add(GenerateLogEntry(rng));
            c++;
        }

        c = 0;
        while (c < 5000)
        {
            Day2Logs.Add(GenerateLogEntry(rng));
            c++;
        }
        
        Validator.Validate(GetLoyalCustomersHanu.GetLoyalCustomers);
        Validator.Validate(GetLoyalCustomersChris.GetLoyalCustomers);
    }

    private static LogEntry GenerateLogEntry(Random generator)
    {
        const int minUserId = 1;
        const int maxUserId = 50;
        const int minPageId = 1;
        const int maxPageId = 100;

        var pageId = generator.Next(minPageId, maxPageId);
        var userId = generator.Next(minUserId, maxUserId);
        return new LogEntry(userId, pageId);
    }

    [Benchmark(Baseline = true)]
    public List<int> Hanu()
    {
        return GetLoyalCustomersHanu.GetLoyalCustomers(Day1Logs, Day2Logs);
    }
    
    [Benchmark]
    public List<int> Unsafe()
    {
        return GetLoyalCustomersUnsafe.GetLoyalCustomers(Day1Logs, Day2Logs);
    }
    
    // [Benchmark]
    // public List<int> Chris()
    // {
    //     return GetLoyalCustomersChris.GetLoyalCustomers(Day1Logs, Day2Logs);
    // }
    
    // [Benchmark]
    // public List<int> Naive()
    // {
    //     return GetLoyalCustomersNaive.GetLoyalCustomers(Day1Logs, Day2Logs);
    // }
}