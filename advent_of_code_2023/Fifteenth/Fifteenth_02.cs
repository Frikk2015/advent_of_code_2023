using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2023.Fifteenth
{
    public class Fifteenth_02
    {
        public Fifteenth_02()
        {
            Console.WriteLine("15-2");
            List<string> allLines = File.ReadAllText(".\\input15.txt").Split(char.Parse(",")).ToList();
            long total = 0;

            List<List<Lens>> boxes = new List<List<Lens>>(256);

            for (int i = 0; i < 256; i++)
            {
                boxes.Add(new List<Lens>());
            }

            foreach (string line in allLines)
            {
                if (line.FirstOrDefault(character => char.IsSymbol(character)).Equals(char.Parse("="))) 
                {
                    if (boxes[GetAscii(line)].Count() > 0)
                    {
                        foreach (Lens lens in boxes[GetAscii(line)])
                        {
                            if (lens.label.Equals(line.Substring(0, line.IndexOf("="))))
                            {
                                lens.value = int.Parse(line.Substring(line.IndexOf(line.First(character => char.IsNumber(character))), line.Count() - line.IndexOf(line.First(character => char.IsNumber(character)))));
                                break;
                            }
                            else if (lens.Equals(boxes[GetAscii(line)][boxes[GetAscii(line)].Count() - 1]))
                            {
                                boxes[GetAscii(line)].Add(new Lens(line.Substring(0, line.IndexOf("=")), int.Parse(line.Substring(line.IndexOf(line.First(character => char.IsNumber(character))), line.Count() - line.IndexOf(line.First(character => char.IsNumber(character)))))));
                                break;
                            }
                        }
                    }
                    else
                    {
                        boxes[GetAscii(line)].Add(new Lens(line.Substring(0, line.IndexOf("=")), int.Parse(line.Substring(line.IndexOf(line.First(character => char.IsNumber(character))), line.Count() - line.IndexOf(line.First(character => char.IsNumber(character)))))));
                    }
                }
                else
                {
                    foreach (Lens lens in boxes[GetAscii(line)] )
                    {
                        if (lens.label.Equals(line.Substring(0, line.IndexOf("-"))))
                        {
                            boxes[GetAscii(line)].Remove(lens);
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < boxes.Count(); i++)
            {
                for (int j = 0; j < boxes[i].Count(); j++)
                {
                    total += (i+1) * (j+1) * boxes[i][j].value;
                }
            }
            Console.WriteLine(total);
        }
        private static int GetAscii(string line)
        {
            int currentValue = 0;
            foreach (char character in line)
            {
                if (!char.IsLetter(character)) continue;
                currentValue = (currentValue + Convert.ToInt32(character)) * 17 % 256;
            }
            return currentValue;
        }
    }
}