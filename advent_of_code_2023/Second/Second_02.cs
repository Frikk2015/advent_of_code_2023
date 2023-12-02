using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Second
{
    public class Second_02
    {
        public Second_02()
        {
            Console.WriteLine("2-2");

            string[] allLines = File.ReadAllLines("C:\\Users\\VETLE\\git\\advent_of_code_2023\\advent_of_code_2023\\Second\\input.txt");

            long total = 0;

            foreach (string line in allLines)
            {
                long gamePower = 0;

                int lowestRed = 0;
                int lowestGreen = 0;
                int lowestBlue = 0;

                string[] games = line.Split(":".ToCharArray());
                string[] game = games[0].Split(" ".ToCharArray());
                int gameNumber = int.Parse(game[1]);
                string[] rounds = games[1].Split(";".ToCharArray());

                foreach (string round in rounds)
                {
                    string[] results = round.Split(",".ToCharArray());
                    foreach (string result in results)
                    {
                        string[] values = result.Trim().Split(" ".ToCharArray());

                        if (values[1].Contains("red"))
                        {
                            if (int.Parse(values[0]) > lowestRed)
                            {
                                lowestRed = int.Parse(values[0]);
                            }
                        }
                        if (values[1].Contains("green"))
                        {
                            if (int.Parse(values[0]) > lowestGreen)
                            {
                                lowestGreen = int.Parse(values[0]);
                            }
                        }
                        if (values[1].Contains("blue"))
                        {
                            if (int.Parse(values[0]) > lowestBlue)
                            {
                                lowestBlue = int.Parse(values[0]);
                            }
                        }
                    }
                }
                gamePower = lowestRed * lowestGreen * lowestBlue;
                total += gamePower;
            }
            Console.WriteLine(total);
        }
    }
}

