namespace Benchmarks.Serialization;

public class Hold
{
    public Hold(int field1, string field2)
    {
        Field1 = field1;
        Field2 = field2;
    }
    
    public int Field1 { get; set; }
    public string Field2 { get; set; }
}