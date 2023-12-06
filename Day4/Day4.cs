namespace Day4;

public static class Day4
{
    public static void Exec()
    {
        var lines = File.ReadAllLines(@"../../../input.txt");
        var sum = lines.Sum(GetCardValue);
        Console.WriteLine(sum);
    }
    
    private static int GetCardValue(string line)
    {
        var cardAndNumbers = line.Split(":");
        var winningAndMyNumbers = cardAndNumbers[1].Split('|');
        var winningNumbersCount = GetYourWinningNumbersCount(winningAndMyNumbers[0].Trim(), winningAndMyNumbers[1].Trim());
        var result = (int)Math.Pow(2, winningNumbersCount - 1);
        return result;
    }

    private static int GetYourWinningNumbersCount(string winningNumbers, string yourNumbers)
    {
        var winNumbers = winningNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var numbers = yourNumbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        return numbers.Count(number => winNumbers.Contains(number));
    }
}