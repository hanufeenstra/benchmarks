namespace Benchmarks.Serialization;

public record HoldDto
{
    public HoldDto(List<int> values)
    {
        Values = values;
    }

    public static HoldDto CreateFromEntity(Hold hold)
    {
        return new HoldDto(hold.Values);
    }

    public List<int> Values { get; init; }
}