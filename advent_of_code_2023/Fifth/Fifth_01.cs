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

            string[] soilMap = { };
            string[] fertilizerMap = { };
            string[] waterMap = { };
            string[] lightMap = { };
            string[] temperatureMap = { };
            string[] humidityMap = { };
            string[] locationMap = { };

            string[] seeds = { };
            string correctMap = "seeds";

            foreach (string line in allLines)
            {
                if (line.Equals("")) continue;


                switch (line)
                {
                    case "seed-to-soil map:":
                        correctMap = "soil";
                        break;
                    case "soil-to-fertilizer map:":
                        correctMap = "fertilizer";
                        break;
                    case "fertilizer-to-water map:":
                        correctMap = "water";
                        break;
                    case "water-to-light map:":
                        correctMap = "light";
                        break;
                    case "light-to-temperature map:":
                        correctMap = "temperature";
                        break;
                    case "temperature-to-humidity map:":
                        correctMap = "humidity";
                        break;
                    case "humidity-to-location map:":
                        correctMap = "location";
                        break;
                }

                switch (correctMap)
                {
                    case "seeds":
                        seeds = line.Replace("seeds: ", "").Split(" ".ToCharArray()[0]);
                        break;
                    case "soil":
                        if (!char.IsDigit(line[0])) break;
                        soilMap = soilMap.Concat(line.Split(" ".ToCharArray()[0])).ToArray();
                        break;
                    case "fertilizer":
                        if (!char.IsDigit(line[0])) break;
                        fertilizerMap = fertilizerMap.Concat(line.Split(" ".ToCharArray()[0])).ToArray();
                        break;
                    case "water":
                        if (!char.IsDigit(line[0])) break;
                        waterMap = waterMap.Concat(line.Split(" ".ToCharArray()[0])).ToArray();
                        break;
                    case "light":
                        if (!char.IsDigit(line[0])) break;
                        lightMap = lightMap.Concat(line.Split(" ".ToCharArray()[0])).ToArray();
                        break;
                    case "temperature":
                        if (!char.IsDigit(line[0])) break;
                        temperatureMap = temperatureMap.Concat(line.Split(" ".ToCharArray()[0])).ToArray();
                        break;
                    case "humidity":
                        if (!char.IsDigit(line[0])) break;
                        humidityMap = humidityMap.Concat(line.Split(" ".ToCharArray()[0])).ToArray();
                        break;
                    case "location":
                        if (!char.IsDigit(line[0])) break;
                        locationMap = locationMap.Concat(line.Split(" ".ToCharArray()[0])).ToArray();
                        break;
                }
            }
            foreach(string seed in seeds)
            {
                int number = int.Parse(seed);
                for (int i = 0; i < soilMap.Length; i += 3)
                {
                    if (number <= int.Parse(soilMap[i]) + int.Parse(soilMap[i + 2]) - 1 && number >= int.Parse(soilMap[i]))
                    {
                        number += (int.Parse(soilMap[i]) - int.Parse(soilMap[i + 1]));
                    }
                }
                Console.WriteLine("seed: " + number);
                for (int i = 0; i < fertilizerMap.Length; i += 3)
                {
                    if (number <= int.Parse(fertilizerMap[i]) + int.Parse(fertilizerMap[i + 2]) - 1 && number >= int.Parse(fertilizerMap[i]))
                    {
                        number += (int.Parse(fertilizerMap[i]) - int.Parse(fertilizerMap[i + 1]));
                    }
                }
                Console.WriteLine("seed: " + number);
                for (int i = 0; i < waterMap.Length; i += 3)
                {
                    if (number <= int.Parse(waterMap[i]) + int.Parse(waterMap[i + 2]) - 1 && number >= int.Parse(waterMap[i]))
                    {
                        number += (int.Parse(waterMap[i]) - int.Parse(waterMap[i + 1]));
                    }
                }
                Console.WriteLine("seed: " + number);
                for (int i = 0; i < lightMap.Length; i += 3)
                {
                    if (number <= int.Parse(lightMap[i]) + int.Parse(lightMap[i + 2]) - 1 && number >= int.Parse(lightMap[i]))
                    {
                        number += (int.Parse(lightMap[i]) - int.Parse(lightMap[i + 1]));
                    }
                }
                Console.WriteLine("seed: " + number);
                for (int i = 0; i < temperatureMap.Length; i += 3)
                {
                    if (number <= int.Parse(temperatureMap[i]) + int.Parse(temperatureMap[i + 2]) - 1 && number >= int.Parse(temperatureMap[i]))
                    {
                        number += (int.Parse(temperatureMap[i]) - int.Parse(temperatureMap[i + 1]));
                    }
                }
                Console.WriteLine("seed: " + number);
                for (int i = 0; i < humidityMap.Length; i += 3)
                {
                    if (number <= int.Parse(humidityMap[i]) + int.Parse(humidityMap[i + 2]) - 1 && number >= int.Parse(humidityMap[i]))
                    {
                        number += (int.Parse(humidityMap[i]) - int.Parse(humidityMap[i + 1]));
                    }
                }
                Console.WriteLine("seed: " + number);
                for (int i = 0; i < locationMap.Length; i += 3)
                {
                    if (number <= int.Parse(locationMap[i]) + int.Parse(locationMap[i + 2]) - 1 && number >= int.Parse(locationMap[i]))
                    {
                        number += (int.Parse(locationMap[i]) - int.Parse(locationMap[i + 1]));
                    }
                }
                Console.WriteLine("seed: " + number);
            }
        }
    }
}
