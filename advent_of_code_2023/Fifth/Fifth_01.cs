using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Fifth
{
    public class Fifth_01
    {
        public Fifth_01() 
        {
            Console.WriteLine("5-1");

            string[] allLines = File.ReadAllLines(".\\input5.txt");

            foreach (string line in allLines)
            {
                string[] seeds = line.Replace("seeds: ", "").Split(" ".ToCharArray()[0]);

                foreach(string seed in seeds)
                {
                    Console.WriteLine(seed);
                }
            }
        }
    }
}
