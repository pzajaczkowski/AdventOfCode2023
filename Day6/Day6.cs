using System.Text.RegularExpressions;

namespace Day6;

public static class Day6
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("../../../input.txt");

        var timesMatches = Regex.Matches(lines[0], @"\d+");
        var recordsMatches = Regex.Matches(lines[1], @"\d+");
        var times = timesMatches.Select(match => int.Parse(match.Value)).ToArray();
        var records = recordsMatches.Select(match => int.Parse(match.Value)).ToArray();

        var result = 1;
        for (var i = 0; i < times.Length; i++) result *= GetWinningTimes(times[i], records[i]);

        Console.WriteLine(result);
    }

    private static int GetWinningTimes(int time, int record)
    {
        var holdingTimes = Enumerable.Range(1, time).ToArray();

        var leftBound = FindLeftBound(holdingTimes, record, time);
        var rightBound = FindRightBound(holdingTimes, record, time);

        Console.WriteLine(rightBound - leftBound + 1);
        return rightBound - leftBound + 1;
    }

    private static int FindLeftBound(int[] array, int record, int time)
    {
        for (var i = 0; i < array.Length; i++)
            if (array[i] * (time - array[i]) > record)
                return i;
        return array.Length - 1;
    }

    private static int FindRightBound(int[] array, int record, int time)
    {
        for (var i = array.Length - 1; i >= 0; i--)
            if (array[i] * (time - array[i]) > record)
                return i;
        return 0;
    }
}