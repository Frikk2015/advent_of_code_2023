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

            string[] allLines = File.ReadAllLines(".\\input3.txt");

            long total = 0;

            for (int line = 0; line < allLines.Length; line++)
            {
                bool lastResult = false;
                int wholeNumber = 0;

                bool shouldBeAdded = false;

                for (int value = 0; value < allLines[line].Length; value++)
                {
                    if (int.TryParse(allLines[line][value].ToString(), out int result))
                    {
                        if (lastResult)
                        {
                            wholeNumber = wholeNumber * 10 + result;
                        }
                        else
                        {
                            wholeNumber = result;
                        }

                        for (int j = 1; j <= 3; j++)
                        {
                            for (int i = 1; i <= 3; i++)
                            {
                                if (allLines[Clamp(line + (- 2 + j), 0, allLines.Length - 1)][Clamp(value + (- 2 + i), 0, allLines[line].Length - 1)] != ".".ToCharArray()[0] && !(char.IsNumber(allLines[Clamp(line + (- 2 + j), 0, allLines.Length - 1)][Clamp(value + (- 2 + i), 0, allLines[line].Length - 1)])))
                                {
                                    shouldBeAdded = true;
                                }
                            }
                        }

                        lastResult = true;
                    }
                    else
                    {

                        if (!(wholeNumber == 0))
                        {
                            if (shouldBeAdded)
                            {
                                total += wholeNumber;
                                Console.WriteLine(wholeNumber);
                            }
                            wholeNumber = 0;
                        }
                        shouldBeAdded = false;
                        lastResult = false;
                    }
                }
                if (!(wholeNumber == 0))
                {
                    if (shouldBeAdded)
                    {
                        total += wholeNumber;
                        Console.WriteLine(wholeNumber);
                    }
                }
            }
            Console.WriteLine(total);
        }

        public static int Clamp(int val, int min, int max)
        {
            if (val < min) return min;
            else if (val > max) return max;
            else return val;
        }
    }
}
