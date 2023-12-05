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

                foreach (string yourValue in yourValues)
                {
                    if (yourValue == "") continue;
                    foreach (string winningValue in winningValues)
                    {
                        if (winningValue == "") continue;
                        if (yourValue == winningValue) correctValues++;
                    }
                }

                if (correctValues == 0) continue;
                total += (long)Math.Pow(2, correctValues - 1);
            }
            Console.WriteLine(total);
        }
    }
}
