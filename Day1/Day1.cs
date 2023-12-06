using System.Reflection;

namespace Day1;

public static class Day1
{
    private static readonly string[] Digits =
        { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    private static readonly Dictionary<string, char> DigitDictionary = new()
    {
        ["one"] = '1', ["two"] = '2', ["three"] = '3', ["four"] = '4',
        ["five"] = '5', ["six"] = '6', ["seven"] = '7', ["eight"] = '8', ["nine"] = '9'
    };

    
    public static void Exec()
    {
        var lines = File.ReadAllLines(@"../../../input.txt");
        var sum = 0;
        foreach (var line in lines)
        {
            var char1 = GetFirstDigit(line);
            var char2 = GetLastDigit(line);
            sum += int.Parse($"{char1}{char2}");
        }
        Console.WriteLine(sum);
    }
    
    private static char GetFirstDigit(string str)
    {
        for (var i = 0; i < str.Length; i++)
        {
            if (char.IsDigit(str[i]))
                return str[i];
            var substring = str.Substring(i - 4 > 0 ? i - 4 : 0, i + 1 > 5 ? 5 : i + 1);
            foreach (var digit in Digits)
            {
                if (substring.Contains(digit)) return DigitDictionary[digit];
            }
        }
        
        throw new Exception("Digit not found");
    }
    
    private static char GetLastDigit(string str)
    {
        for (var i = str.Length-1; i >=0; i--)
        {
            if (char.IsDigit(str[i]))
                return str[i];
            var substring = str.Substring(i, str.Length-1 - i > 5 ? 5 : str.Length - i);
            foreach (var digit in Digits)
            {
                if (substring.Contains(digit)) return DigitDictionary[digit];
            }
        }

        throw new Exception("Digit not found");
    }
}