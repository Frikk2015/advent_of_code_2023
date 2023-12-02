using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.First
{
    public class First_1
    {
        public First_1() 
        {
            Console.WriteLine("1-1");

            string[] lines = File.ReadAllLines("C:\\Users\\VETLE\\git\\advent_of_code_2023\\advent_of_code_2023\\First\\input.txt");

            int _number = 0;

            int _newNumber = 0;

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsDigit(line[i]))
                    {
                        _newNumber = int.Parse(line[i].ToString());
                        break;
                    }
                }
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (Char.IsDigit(line[i]))
                    {
                        _newNumber = _newNumber * 10 + int.Parse(char.ToString(line[i]));
                        break;
                    }
                }
                _number += _newNumber;
            }
            Console.WriteLine(_number);
        }
    }
}
