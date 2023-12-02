using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Second
{
    public class Second_01
    {
        public Second_01() 
        {
            Console.WriteLine("2-1");

            string[] allLines = File.ReadAllLines("C:\\Users\\VETLE\\git\\advent_of_code_2023\\advent_of_code_2023\\Second\\input.txt");

            long total = 0;

            foreach (string line in allLines)
            {
                string[] games = line.Split(":".ToCharArray());

                string[] game = games[0].Split(" ".ToCharArray());

                int gameNumber  = int.Parse(game[1]);

                string[] rounds = games[1].Split(";".ToCharArray());

                bool shouldAddNumber = true;

                foreach (string round in rounds)
                {
                    string[] results = round.Split(",".ToCharArray());
                    foreach (string result in results)
                    {
                        string[] values = result.Trim().Split(" ".ToCharArray());

                        if (values[1].Contains("red"))
                        {
                            if (int.Parse(values[0]) > 12)
                            {
                                shouldAddNumber = false;
                            }
                        }
                        if (values[1].Contains("green"))
                        {
                            if (int.Parse(values[0]) > 13)
                            {
                                shouldAddNumber = false;
                            }
                        }
                        if (values[1].Contains("blue"))
                        {
                            if (int.Parse(values[0]) > 14)
                            {
                                shouldAddNumber = false;
                            }
                        }
                    }
                }
                if (shouldAddNumber)
                {
                    total += gameNumber;
                }
            }
            Console.WriteLine(total);
        }
    }
}
