namespace Day2;

public static class Day2
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;
    
    public static void Exec()
    {
        var lines = File.ReadAllLines(@"../../../input.txt");
        var sum = lines.Sum(GetGamePower);
        Console.WriteLine(sum);
    }

    private static int GetGamePower(string line)
    {
        var gameAndSets = line.Split(":");
        var minGameColors = new MinGameColors();

        var sets = gameAndSets[1].Split(";");
        foreach (var set in sets)
        {
            var colors = set.Split(",");
            foreach (var color in colors)
            {
                CheckMinColors(color, minGameColors);
            }
        }

        return minGameColors.Power;
    }

    private static void CheckMinColors(string color, MinGameColors minGameColors)
    {
        var numberColor = color.Trim().Split(" ");
        var number = int.Parse(numberColor[0]);
        switch (numberColor[1])
        {
            case "red":
                minGameColors.MinRed = int.Max(minGameColors.MinRed, number);
                break;
            case "green":
                minGameColors.MinGreen = int.Max(minGameColors.MinGreen, number);
                break;
            case "blue":
                minGameColors.MinBlue = int.Max(minGameColors.MinBlue, number);
                break;
        }
    }
}

public class MinGameColors
{
    public int MinRed { get; set; } = 0;
    public int MinGreen { get; set; } = 0;
    public int MinBlue { get; set; } = 0;

    public int Power => MinRed * MinGreen * MinBlue;
}