using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serialization.Extensions;

namespace Benchmarks.Serialization;

public class SerializationBenchmark
{
    public List<int> initialValuesList = [];
    public List<Hold> Holds = [];

    [Params(1000)]
    public int holds;
    
    [Params(2000)]
    public int children;
    
    [GlobalSetup]
    public void Setup()
    {
        Console.WriteLine("setup");
        initialValuesList = Enumerable.Range(0, holds).ToList();

        foreach (var i in initialValuesList)
        {
            Holds.Add(new Hold(Enumerable.Range(0, children).ToList(), i, i.ToString()));
        }
    }

    [Benchmark]
    public string ToListNoInitDto()
    {
        var dto = Holds.ToListDto();
        var s = JsonSerializer.Serialize(dto);
        return s;
    }
    
    [Benchmark]
    public string ToListInitForeachDto()
    {
        var dto = Holds.ToInitListForeachDto();
        var s = JsonSerializer.Serialize(dto);
        return s;
    }

    [Benchmark]
    public string ToListInitForDto()
    {
        var dto = Holds.ToInitListForDto();
        var s = JsonSerializer.Serialize(dto);
        return s;
    }
    
    [Benchmark]
    public string ToLinqDto()
    {
        var dto = Holds.ToListLinq();
        var s = JsonSerializer.Serialize(dto);
        return s;
    }
}