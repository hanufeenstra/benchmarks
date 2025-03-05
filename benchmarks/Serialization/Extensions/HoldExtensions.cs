namespace Benchmarks.Serialization.Extensions;

public static class HoldExtensions
{
    public static HoldDto ToDto(this Hold hold) => HoldDto.CreateFromEntity(hold);

    public static IEnumerable<HoldDto> ToEnumerableSelect(this IEnumerable<Hold> holds)
    {
        return holds.Select(x => new HoldDto(x.Field1, x.Field2));
    }
    
    public static IEnumerable<HoldDto> ToListConvertAllToEnumerable(this List<Hold> holds)
    {
        return holds.ConvertAll(x => new HoldDto(x.Field1, x.Field2));
    }
    
    public static List<HoldDto> ToListConvertAllToList(this List<Hold> holds)
    {
        return holds.ConvertAll(x => new HoldDto(x.Field1, x.Field2)).ToList();
    }
    
    public static HoldDto[] ToListConvertAllToArray(this List<Hold> holds)
    {
        return holds.ConvertAll(x => new HoldDto(x.Field1, x.Field2)).ToArray();
    }

    public static List<HoldDto> ToInitListForeach(this List<Hold> holds)
    {
        List<HoldDto> holdsDto = new List<HoldDto>(holds.Count);

        foreach (var hold in holds)
        {
            holdsDto.Add(HoldDto.CreateFromEntity(hold));
        }

        return holdsDto;
    }
    
    public static HoldDto[] ArrayToArraySelect(this Hold[] holds)
    {
        return holds.Select(HoldDto.CreateFromEntity).ToArray();
    }
    
    public static IEnumerable<HoldDto> ArrayToEnumerableSelect(this Hold[] holds)
    {
        return holds.Select(HoldDto.CreateFromEntity);
    }
}