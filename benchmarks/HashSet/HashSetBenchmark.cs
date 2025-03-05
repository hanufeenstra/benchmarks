using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Benchmarks.Config;

namespace Benchmarks.HashSet;

[Config(typeof(BenchmarkConfig))]
public class HashSetBenchmark
{
    private List<string> strings { get; } = [];

    [GlobalSetup]
    public void Setup()
    {
        var rng = new Random((int)DateTime.Now.Ticks);

        var c = 0;
        while (c < 100000)
        {
            strings.Add(GenerateString(rng));
            c++;
        }
    }

    private static string GenerateString(Random generator)
    {
        var number = generator.Next(0, 1000);
        return number.ToString();
    }

    [Benchmark]
    public HashSet<string> CreateSet()
    {
        return strings.ToHashSet();
    }
}