using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2023.Fifteenth
{
    public class Fifteenth_01
    {
        public Fifteenth_01()
        {
            Console.WriteLine("15-1");
            List<string> allLines = File.ReadAllText(".\\input15.txt").Split(char.Parse(",")).ToList();
            long total = 0;
            foreach (string line in allLines)
            {
                int currentValue = 0;
                foreach (char character in line)
                {
                    currentValue = (currentValue + Convert.ToInt32(character)) * 17 % 256;
                }
                total += currentValue;
            }
            Console.WriteLine(total);
        }
    }
}