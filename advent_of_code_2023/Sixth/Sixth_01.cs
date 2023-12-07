using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Sixth
{
    public class Sixth_01
    {
        public Sixth_01() 
        {
            Console.WriteLine("6-1");
            string[] allLines = File.ReadAllLines("./input6.txt");
            long total = 1;

            string[] timeValues = allLines[0].Substring(11).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] distValues = allLines[1].Substring(11).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < timeValues.Length; i++)
            {
                int possibleRecords = 0;
                int timeValue = int.Parse(timeValues[i]);
                int distValue = int.Parse(distValues[i]);
                for (int j = 0; j < timeValue; j++)
                {
                    if (j * (timeValue - j) > distValue)
                    {
                        possibleRecords++;
                    }
                }
                total *= possibleRecords;
            }
            Console.WriteLine(total);
        }
    }
}
