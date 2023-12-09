using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Eight
{
    public class Eight_01
    {
        public Eight_01() 
        {
            Console.WriteLine("8-1");
            string[] allLines = File.ReadAllLines("./input8.txt");
            long total = 0;

            List<int> order = GetNumber(allLines[0]);

            string[] valueLines = allLines.Skip(2).ToArray();

            string currentNode = "AAA";

            while (currentNode != "ZZZ")
            {
                foreach (int currentOrder  in order) 
                {
                    foreach (string line in valueLines)
                    {
                        string[] newLine = line.Split("=".ToCharArray());
                        string currentValue = newLine[0].Trim();
                        string[] newValues = newLine[1].Replace(" ", "").Replace("(", "").Replace(")", "").Split(",".ToCharArray()[0]);
                        if (currentValue == currentNode)
                        {
                            currentNode = newValues[currentOrder];
                            total++;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(total);
        }
        private List<int> GetNumber(string lr)
        {
            char[] chars = lr.ToCharArray();
            List<int> numbers = new List<int>();

            foreach (char c in chars) 
            {
                if (c == 'R')
                {
                    numbers.Add(1);
                }
                else if (c == 'L')
                {
                    numbers.Add(0);
                }
            }
            return numbers;
        }
    }
}
