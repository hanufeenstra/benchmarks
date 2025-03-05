// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using BenchmarkDotNet.Running;
using Benchmarks.HashSet;
using Benchmarks.Interviews;
using Benchmarks.Interviews.Hanu;
using Benchmarks.Interviews.Shared;

//BenchmarkRunner.Run<InterviewBenchmark>();
// BenchmarkRunner.Run<HashSetBenchmark>();


var userPageDictionary = new Dictionary<int, string>();

userPageDictionary.Add(1, "1");
userPageDictionary.Add(2, "3");
userPageDictionary[3] = "3";
userPageDictionary[2] = "2";

Console.WriteLine(JsonSerializer.Serialize(userPageDictionary));
