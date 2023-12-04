using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace advent_of_code_2023.Third
{
    public class Third_01
    {
        public Third_01()
        {
            Console.WriteLine("3-1");

            string[] allLines = File.ReadAllLines("C:\\Users\\vetlefon\\git\\advent_of_code_2023\\advent_of_code_2023\\Third\\input.txt");

            long total = 0;

            foreach (string line in allLines)
            {
                bool lastResult = false;
                int wholeNumber = 0;
                foreach (char value in line)
                {
                    if (int.TryParse(value.ToString(), out int result))
                    {
                        if (lastResult)
                        {
                            wholeNumber = wholeNumber * 10 + result;
                        }
                        else
                        {
                            wholeNumber = result;
                        }

                        lastResult = true;
                        Console.WriteLine(wholeNumber);
                    }
                    else
                    {
                        lastResult = false;
                    }
                }
            }
        }
    }
}
