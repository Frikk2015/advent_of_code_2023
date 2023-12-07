using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Sixth
{
    public class Sixth_02
    {
        public Sixth_02()
        {
            Console.WriteLine("6-2");
            string[] allLines = File.ReadAllLines("./input6.txt");
            long total = 0;

            string[] timeValues = allLines[0].Substring(11).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] distValues = allLines[1].Substring(11).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            long timeValue = long.Parse(string.Join("", timeValues));
            long distValue = long.Parse(string.Join("", distValues));

            long possibleRecords = 0;
            for (long j = 0; j < timeValue; j++)
            {
                if (j * (timeValue - j) > distValue)
                {
                    possibleRecords++;
                }
            }
            total += possibleRecords;

            Console.WriteLine(total);
        }
    }
}
