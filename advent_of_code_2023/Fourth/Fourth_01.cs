using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace advent_of_code_2023.Fourth
{
    public class Fourth_01
    {
        public Fourth_01() 
        {
            Console.WriteLine("4-1");

            string[] allLines = File.ReadAllLines(".\\input4.txt");

            long total = 0;

            foreach (string line in allLines)
            {
                string[] allValues = line.Split(":".ToCharArray()[0]);

                string[] columns = allValues[1].Split("|".ToCharArray()[0]);

                string[] winningValues = columns[0].Trim().Split(" ".ToCharArray()[0]);
                string[] yourValues = columns[1].Trim().Split(" ".ToCharArray()[0]);

                int correctValues = 0;

                for (int i = 0; i < yourValues.Length; i++)
                {
                    if (yourValues[i] == null) continue;
                    for (int j = 0; j < winningValues.Length; j++)
                    {
                        if (winningValues[j] == "") continue;
                        if (yourValues[i] == winningValues[j]) { correctValues++; Console.WriteLine(yourValues[i]); Console.WriteLine(winningValues[j]); };
                    }
                }

                if (correctValues == 0) continue;
                Console.WriteLine(correctValues);
                total += (long)Math.Pow(2, correctValues - 1);
            }
            Console.WriteLine(total);
        }
    }
}
