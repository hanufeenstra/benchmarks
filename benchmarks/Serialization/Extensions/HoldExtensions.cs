namespace Benchmarks.Serialization.Extensions;

public static class HoldExtensions
{
    public static HoldDto ToDto(this Hold hold) => HoldDto.CreateFromEntity(hold);

    public static List<HoldDto> ToListDto(this List<Hold> holds)
    {
        List<HoldDto> holdsDto = [];

        foreach (var hold in holds)
        {
            holdsDto.Add(HoldDto.CreateFromEntity(hold));
        }

        return holdsDto;
    }

    public static List<HoldDto> ToInitListForeachDto(this List<Hold> holds)
    {
        List<HoldDto> holdsDto = new List<HoldDto>(holds.Count);

        foreach (var hold in holds)
        {
            holdsDto.Add(HoldDto.CreateFromEntity(hold));
        }

        return holdsDto;
    }

    public static List<HoldDto> ToInitListForDto(this List<Hold> holds)
    {
        List<HoldDto> holdsDto = new List<HoldDto>(holds.Count);

        for (int i = 0; i < holds.Count; i++)
        {
            holdsDto.Add(HoldDto.CreateFromEntity(holds[i]));
        }
        
        return holdsDto;
    }

    public static List<HoldDto> ToListLinq(this List<Hold> holds)
    {
        List<HoldDto> holdsDto = new List<HoldDto>(holds.Count);
        holdsDto.AddRange(holds.Select(HoldDto.CreateFromEntity));
        return holdsDto;
    }
}