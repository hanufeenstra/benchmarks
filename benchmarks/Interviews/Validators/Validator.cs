using System.Text.Json;
using Benchmarks.Interviews.Shared;

namespace Benchmarks.Interviews.Validators;

public static class Validator
{
    public static void Validate(Func<List<LogEntry>, List<LogEntry>, List<int>> testingFunction)
    {
        List<LogEntry> day1Test1 = [new LogEntry(1,1)];
        List<LogEntry> day2Test1 = [new LogEntry(1,2)];
        List<int> test1Result = [1];

        var testingFunctionResult = testingFunction(day1Test1, day2Test1);
        
        List<LogEntry> day1Test2 = 
        [
            new LogEntry(1,1),
            new LogEntry(1,2),
            new LogEntry(2,1)
        ];
        
        List<LogEntry> day2Test2 = 
        [
            new LogEntry(1,1),
            new LogEntry(2,1),
            new LogEntry(2,2)
        ];
        
        List<int> test2Result = [1, 2];

        var testingFunctionResult2 = testingFunction(day1Test2, day2Test2);
        
        List<LogEntry> day1Test3 = 
        [
            new LogEntry(1,1),
            new LogEntry(2,2),
            new LogEntry(3,3)
        ];
        
        List<LogEntry> day2Test3 = 
        [
            new LogEntry(4,4),
            new LogEntry(5,5),
            new LogEntry(6,6)
        ];
        List<int> test3Result = [];
        
        var testingFunctionResult3 = testingFunction(day1Test3, day2Test3);

        Console.WriteLine($"Test 1: expected {JsonSerializer.Serialize(test1Result)}, actual: {JsonSerializer.Serialize(testingFunctionResult)}");
        Console.WriteLine($"Test 2: expected {JsonSerializer.Serialize(test2Result)}, actual: {JsonSerializer.Serialize(testingFunctionResult2)}");
        Console.WriteLine($"Test 3: expected {JsonSerializer.Serialize(test3Result)}, actual: {JsonSerializer.Serialize(testingFunctionResult3)}");
    }
}