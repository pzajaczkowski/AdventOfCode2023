namespace Day5;

public static class Day5
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("../../../input.txt");
        
        var seeds = lines[0].Substring(7).Split(" ").Select(long.Parse).ToList();
        List<CategoryMap> maps = new();

        // create maps
        int i;
        List<string> mapLines = new();
        for (i = 3; i < lines.Length; i++)
        {
            if (lines[i].Length == 0)
            {
                maps.Add(new CategoryMap(mapLines));
                mapLines = new List<string>();
                i++;
                continue;
            }
            mapLines.Add(lines[i]);
        }
        maps.Add(new CategoryMap(mapLines));
        
        // calculate location for each seed
        var seedLocations = new List<long>();
        foreach (var seed in seeds)
        {
            var mappedSeed = seed;
            foreach (var map in maps)
            {
                foreach (var range in map.Ranges)
                {
                    var result = range.GetValueFor(mappedSeed);
                    if (result == -1) continue;
                    mappedSeed = result;
                    break;
                }
            }
            seedLocations.Add(mappedSeed);
        }

        Console.WriteLine(seedLocations.Min());
    }
}

public class CategoryMap
{
    public List<Range> Ranges { get; } = new();

    public CategoryMap(List<string> mapLines)
    {
        foreach (var ranges in mapLines.Select(GetRangeFromString))
        {
            Ranges.Add(new Range(ranges[1], ranges[1] + ranges[2], ranges[0]));
        }
    }
    
    private static long[] GetRangeFromString(string line)
    {
        return line.Split(" ").Select(long.Parse).ToArray();
    }
}

public record Range(long Start, long End, long Value)
{
    public long GetValueFor(long index) => Contains(index) ? Value + index - Start : -1;
    private bool Contains(long index) => index >= Start && index <= End;
};