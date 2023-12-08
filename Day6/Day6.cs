namespace Day6;

public static class Day6
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("../../../input.txt");

        var time = lines[0].Split(":")[1].Replace(" ", "");
        var record = lines[1].Split(":")[1].Replace(" ", "");

        var result = FindBounds(long.Parse(record), long.Parse(time));
        Console.WriteLine(result);
    }

    private static long FindBounds(long record, long time)
    {
        long leftBound, rightBound;
        // find left bound first
        leftBound = FindLeftBound(1, time - 1, record, time);
        // if left bound not found, find right bound first instead
        if (leftBound == time - 1)
        {
            rightBound = FindRightBound(1, time - 1, record, time);
            // find left bound on restricted range
            leftBound = FindLeftBound(1, rightBound, record, time);
        }
        else
        {
            rightBound = FindRightBound(leftBound, time - 1, record, time);
        }

        return rightBound - leftBound;
    }

    private static long FindLeftBound(long left, long right, long record, long time)
    {
        long l = left, r = right;
        while (l <= r)
        {
            var m = l + (r - l) / 2;
            if (m * (time - m) < record) l = m + 1;
            else r = m - 1;
        }
        return l;
    }

    private static long FindRightBound(long left, long right, long record, long time)
    {
        long l = left, r = right;
        while (l <= r)
        {
            var m = l + (r - l) / 2;
            if (m * (time - m) < record) r = m - 1;
            else l = m + 1;
        }
        return l;
    }
}