using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Benchmarks.Config;
using Benchmarks.ResultType;

namespace Benchmarks.Serialization;

[Config(typeof(BenchmarkConfig))]
public class SerializationBenchmark
{
    public List<int> initialValuesList = [];
    public List<Hold> Holds = [];

    public IEnumerable<Hold> HoldsE = [];

    [Params(10_000)]
    public int holds;
    
    [GlobalSetup]
    public void Setup()
    {
        Console.WriteLine("setup");
        initialValuesList = Enumerable.Range(0, holds).ToList();

        foreach (var i in initialValuesList)
        {
            Holds.Add(new Hold(i, i.ToString()));
        }

        HoldsE = Holds;
    }

    [Benchmark]
    public string ValueResult()
    {
        var dto = HoldsE.Select(HoldDto.CreateFromEntity);
        return "";
    }
}