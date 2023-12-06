namespace Day4;

public static class Day4
{
    public static void Exec()
    {
        var lines = File.ReadAllLines("../../../input.txt");
        var cardsInstances = Enumerable.Repeat(1, lines.Length).ToArray();
        foreach (var item in lines.Select((line, i) => ( line, i )))
        {
            CalculateCardValue(item.line, item.i, cardsInstances);
        }
        Console.WriteLine(cardsInstances.Sum());
    }
    
    private static void CalculateCardValue(string line, int index, int[] cardsInstances)
    {
        var cardAndNumbers = line.Split(":");
        var winningAndMyNumbers = cardAndNumbers[1].Split('|');
        var winningNumbersCount = GetYourWinningNumbersCount(winningAndMyNumbers[0].Trim(), winningAndMyNumbers[1].Trim());
        for (var i = 1; i <= winningNumbersCount; i++)
        {
            cardsInstances[index + i] += cardsInstances[index];
        }
    }

    private static int GetYourWinningNumbersCount(string winningNumbers, string yourNumbers)
    {
        var winNumbers = winningNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var numbers = yourNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return numbers.Count(number => winNumbers.Contains(number));
    }
}