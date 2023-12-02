using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.First
{
    public class First_2
    {
        public First_2() 
        {
            Console.WriteLine("1-2");

            string[] lines = File.ReadAllLines("C:\\Users\\VETLE\\git\\advent_of_code_2023\\advent_of_code_2023\\First\\input.txt");

            int _number = 0;

            int _newNumber = 0;

            foreach (string line in lines)
            {
                string newLine = line;

                newLine = newLine.Replace("one", "1");
                newLine = newLine.Replace("two", "2");
                newLine = newLine.Replace("three", "3");
                newLine = newLine.Replace("four", "4");
                newLine = newLine.Replace("five", "5");
                newLine = newLine.Replace("six", "6");
                newLine = newLine.Replace("seven", "7");
                newLine = newLine.Replace("eight", "8");
                newLine = newLine.Replace("nine", "9");

                for (int i = 0; i < newLine.Length; i++)
                {
                    if (Char.IsDigit(newLine[i]))
                    {
                        _newNumber = int.Parse(newLine[i].ToString());
                        break;
                    }
                }
                for (int i = newLine.Length - 1; i >= 0; i--)
                {
                    if (Char.IsDigit(newLine[i]))
                    {
                        _newNumber = _newNumber * 10 + int.Parse(char.ToString(newLine[i]));
                        break;
                    }
                }
                Console.WriteLine(_newNumber);
                _number += _newNumber;
            }
            Console.WriteLine(_number);
        }
    }
}
