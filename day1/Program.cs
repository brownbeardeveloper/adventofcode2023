class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader("file.txt");

        string line = sr.ReadLine();
        int sum = 0;

        while (line != null)
        {
            line = line
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "f4r")
            .Replace("five", "f5e")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");

            char? firstDigit = null;
            char? lastDigit = null;

            foreach (char c in line)
            {
                if (Char.IsDigit(c))
                {
                    if(firstDigit == null) { firstDigit = c; }
                    lastDigit = c;
                }
            }

            string combinedDigits = firstDigit.ToString() + lastDigit.ToString();
            Console.WriteLine(combinedDigits);

            if (int.TryParse(combinedDigits, out int result))
            {
                sum += result;
            }
            line = sr.ReadLine();
        }
        sr.Close();
        Console.WriteLine("The sum is " + sum);
    }
}
