class Program
{
    static void Main()
    {
        string path = "file.txt";
        string content = File.ReadAllText(path);
        string[] lines = content.Split('\n');
        int sum = 0;

        foreach(string line in lines)
        {
            int gameID = 0;
            int minRedCubes = 0;
            int minGreenCubes = 0;
            int minBlueCubes = 0;

            String[] spearators = { ":", ";" };
            String[] lineArray = line.Split(spearators, StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in lineArray)
            {
                if (s.Contains("Game"))
                {
                    String trimmedLine = s.Replace("Game", "").Trim();
                    int.TryParse(trimmedLine, out gameID);
                }

                String[] cubes = s.Split(",",StringSplitOptions.RemoveEmptyEntries);

                foreach (String c in cubes)
                {
                    if (c.Contains("blue"))
                    {
                        String trimmedBlueLine = c.Replace("blue", "").Trim();
                        if (int.TryParse(trimmedBlueLine, out int blueCubes))
                        {
                            if (blueCubes > minBlueCubes)
                            {
                                minBlueCubes = blueCubes;
                            }
                        }
                    }

                    if (c.Contains("green"))
                    {
                        String trimmedGreenLine = c.Replace("green", "").Trim();
                        if (int.TryParse(trimmedGreenLine, out int greenCubes))
                        {
                            if (greenCubes > minGreenCubes)
                            {
                                minGreenCubes = greenCubes;
                            }
                        }
                    }

                    if (c.Contains("red"))
                    {
                        String trimmedRedLine = c.Replace("red", "").Trim();
                        if (int.TryParse(trimmedRedLine, out int redCubes))
                        {
                            if (redCubes > minRedCubes) {
                                minRedCubes = redCubes; 
                            }
                        }
                    }
                }
            }
                sum += minBlueCubes * minGreenCubes * minRedCubes;
        }
        Console.WriteLine("The sum is " + sum);
    }
}
