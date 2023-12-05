using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string path = "file.txt";
        string content = File.ReadAllText(path);
        string[] lines = content.Split('\n');

        string num = "";
        int sum = 0;
        bool keepNum = false;


        for (int i = 0; i < lines.Length; i++) // each line in lines
        {
            for (int j = 0; j < lines[i].Length; j++) // each char in the line
            {
                // Console.WriteLine($"Checking position ({i}, {j}): {lines[i][j]}");

                if (Char.IsDigit(lines[i][j]))
                {
                    num += lines[i][j];
                    if (adjacent(lines, i, j))
                    {
                        keepNum = true;
                        // Console.WriteLine($"Adjacent digit found at position ({i}, {j})");
                    }
                }
                else
                {
                    if (keepNum && num.Length != 0)
                    {
                        sum += int.Parse(num);
                        Console.WriteLine($"Sum updated to {sum} with {num}");
                    }
                    keepNum = false;
                    num = "";
                }
                   // Console.WriteLine("keepNum: " + keepNum);
            }

            if (keepNum && num.Length != 0)
            {
                sum += int.Parse(num);
                Console.WriteLine($"Sum updated to {sum} with {num}");
            }
            keepNum = false;
        }
        Console.WriteLine("The sum is " + sum); 
    }

    static bool adjacent(string[] lines, int i, int j)
    {
        string pattern = @"[^\d.]";
        Regex regex = new Regex(pattern);

        if (i == 0) // start line
        {
            if (j == 0)
            {
                return regex.IsMatch(lines[i][j + 1].ToString()) ||
                    regex.IsMatch(lines[i + 1][j].ToString()) || regex.IsMatch(lines[i + 1][j + 1].ToString());
            }
            else if (j == lines[i].Length - 1)
            {
                return regex.IsMatch(lines[i][j - 1].ToString()) ||
                    regex.IsMatch(lines[i + 1][j - 1].ToString()) || regex.IsMatch(lines[i + 1][j].ToString());
            }
            else
            {
                return regex.IsMatch(lines[i][j - 1].ToString()) || regex.IsMatch(lines[i][j + 1].ToString()) ||
                    regex.IsMatch(lines[i + 1][j - 1].ToString()) || regex.IsMatch(lines[i + 1][j].ToString()) || regex.IsMatch(lines[i + 1][j + 1].ToString());
            }
        }
        else if (i == lines.Length-1) // bottom line
        {
            if (j == 0)
            {
                return regex.IsMatch(lines[i - 1][j].ToString()) || regex.IsMatch(lines[i - 1][j + 1].ToString()) ||
                    regex.IsMatch(lines[i][j + 1].ToString());
            }
            else if (j == lines[i].Length-1)
            {
                return regex.IsMatch(lines[i - 1][j - 1].ToString()) || regex.IsMatch(lines[i - 1][j].ToString()) ||
                    regex.IsMatch(lines[i][j - 1].ToString());
            }
            else
            {
                return regex.IsMatch(lines[i - 1][j - 1].ToString()) || regex.IsMatch(lines[i - 1][j].ToString()) || regex.IsMatch(lines[i - 1][j + 1].ToString()) ||
                    regex.IsMatch(lines[i][j - 1].ToString()) || regex.IsMatch(lines[i][j + 1].ToString());
            }

        }
        else
        {
            if (j == 0)
            {
                return regex.IsMatch(lines[i - 1][j].ToString()) || regex.IsMatch(lines[i - 1][j + 1].ToString()) ||
                    regex.IsMatch(lines[i][j + 1].ToString()) ||
                    regex.IsMatch(lines[i + 1][j].ToString()) || regex.IsMatch(lines[i + 1][j + 1].ToString());
            }
            else if (j == lines[i].Length-1)
            {
                return regex.IsMatch(lines[i - 1][j - 1].ToString()) || regex.IsMatch(lines[i - 1][j].ToString()) ||
                    regex.IsMatch(lines[i][j - 1].ToString()) ||
                    regex.IsMatch(lines[i + 1][j - 1].ToString()) || regex.IsMatch(lines[i + 1][j].ToString());
            }
            else
            {
                return regex.IsMatch(lines[i - 1][j - 1].ToString()) || regex.IsMatch(lines[i - 1][j].ToString()) || regex.IsMatch(lines[i - 1][j + 1].ToString()) ||
                    regex.IsMatch(lines[i][j - 1].ToString()) || regex.IsMatch(lines[i][j + 1].ToString()) ||
                    regex.IsMatch(lines[i + 1][j - 1].ToString()) || regex.IsMatch(lines[i + 1][j].ToString()) || regex.IsMatch(lines[i + 1][j + 1].ToString());
            }
        }
    }
}
