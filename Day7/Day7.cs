namespace Day7;

public static class Day7
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("../../../input.txt");
        var handsWithBids = lines.Select(t => t.Split(" ")).Select(handBid => (handBid[0], int.Parse(handBid[1])))
            .ToList();

        handsWithBids.Sort(new CardComparer());
        var result = handsWithBids.Select((tuple, i) => tuple.Item2 * (i + 1)).Sum();
        Console.WriteLine(result);
    }
}

public class CardComparer : IComparer<(string, int)>
{
    private static readonly Dictionary<char, int> CardDict = new()
    {
        { 'A', 14 },
        { 'K', 13 },
        { 'Q', 12 },
        { 'J', 11 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 }
    };

    public int Compare((string, int) x, (string, int) y)
    {
        var xType = GetHandType(x.Item1);
        var yType = GetHandType(y.Item1);

        // different card type
        if (xType > yType) return 1;
        if (xType < yType) return -1;

        // // same card type
        // if (xType != 0) // 1 higher card case
        return CompareCards(x.Item1, y.Item1);
    }

    private static int GetHandType(string hand)
    {
        var handDict = hand.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        return handDict.Count switch
        {
            1 => 6, // Five
            2 => handDict.ContainsValue(4) ? 5 : 4, // Four, house
            3 => handDict.ContainsValue(3) ? 3 : 2, // Three, two pair
            4 => 1, // Pair
            _ => 0 // Highest card
        };
    }

    private static int CompareCards(string x, string y)
    {
        for (var i = 0; i < x.Length; i++)
        {
            var xValue = CardDict[x[i]];
            var yValue = CardDict[y[i]];
            if (xValue > yValue) return 1;
            if (xValue < yValue) return -1;
        }

        return 0;
    }
}