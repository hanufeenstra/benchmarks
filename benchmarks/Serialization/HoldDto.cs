namespace Benchmarks.Serialization;

public record HoldDto
{
    public HoldDto(int field1, string field2)
    {
        Field1 = field1;
        Field2 = field2;
    }

    public static HoldDto CreateFromEntity(Hold hold)
    {
        return new HoldDto(hold.Field1, hold.Field2);
    }

    public int Field1 { get; init; }
    public string Field2 { get; init; }
}