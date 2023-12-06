namespace Day3;

public static class Day3
{
    public static void Exec()
    {
        var lines = File.ReadAllLines(@"../../../input.txt");
        var sum = ForeachSymbol(lines);
        Console.WriteLine(sum);
    }

    private static int ForeachSymbol(string[] lines)
    {
        var sum = 0;
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                var ch = lines[y][x];
                if(ch!='*') continue;
                sum+=CheckSurrounding(x,y,lines);
            }
        }

        return sum;
    }

    private static int CheckSurrounding(int xs, int ys, string[] lines)
    {
        var surrSum = 1;
        var i = 0;
        for (var y = ys - 1 >= 0 ? ys -1 : 0; y <= ys+1; y++)
        {
            var isAdjacent = false;
            for (var x = xs - 1 >= 0 ? xs - 1 : 0; x <= xs + 1; x++)
            {
                if(!char.IsDigit(lines[y][x]))
                {
                    isAdjacent = false;
                    continue;
                }
                if (isAdjacent) continue;
                
                surrSum *= FindNumberInString(x, y, lines);
                isAdjacent = true;
                i++;
            }
        }

        return i == 2 ? surrSum : 0;
    }

    private static int FindNumberInString(int x, int y, string[] lines)
    {
        var line = lines[y];
        var i = 1;
        string number = lines[y][x].ToString();
        bool isLeftDigit = true, isRightDigit = true;
        while ((isLeftDigit&&x-i>=0)||(isRightDigit&&x+i<line.Length))
        {
            if (x - i >= 0 && isLeftDigit)
            {
                var leftChar = line[x - i];
                isLeftDigit = char.IsDigit(leftChar);
                if (isLeftDigit)
                    number = leftChar + number;
            }
            if (x + i < line.Length && isRightDigit)
            {
                var rightChar = line[x + i];
                isRightDigit = char.IsDigit(rightChar);
                if (isRightDigit)
                    number += rightChar;
            }
            i++;
        }
        
        return int.Parse(number);
    }
}