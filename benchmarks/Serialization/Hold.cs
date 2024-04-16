namespace Benchmarks.Serialization;

public class Hold
{
    public Hold(List<int> values, int field1, string field2)
    {
        Values = values;
        Field1 = field1;
        Field2 = field2;
    }

    public List<int> Values { get; set; }
    public int Field1 { get; set; }
    public string Field2 { get; set; }
}