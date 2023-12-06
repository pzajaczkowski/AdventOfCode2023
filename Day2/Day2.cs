namespace Day2;

public static class Day2
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;
    
    public static void Exec()
    {
        var lines = File.ReadAllLines(@"../../../input.txt");
        var sum = lines.Sum(IsValidGame);
        Console.WriteLine(sum);
    }

    private static int IsValidGame(string line)
    {
        var gameAndSets = line.Split(":");
        var gameNumber = int.Parse(gameAndSets[0].Substring(5, gameAndSets[0].Length - 5));

        var sets = gameAndSets[1].Split(";");
        foreach (var set in sets)
        {
            var colors = set.Split(",");
            if (colors.Any(IsColorOverLimit))
            {
                return 0;
            }
        }

        return gameNumber;
    }

    private static bool IsColorOverLimit(string color)
    {
        var numberColor = color.Trim().Split(" ");
        var number = int.Parse(numberColor[0]);
        switch (numberColor[1])
        {
            case "red":
                if (number > MaxRed) return true;
                break;
            case "green":
                if (number > MaxGreen) return true;
                break;
            case "blue":
                if (number > MaxBlue) return true;
                break;
        }

        return false;
    }
}