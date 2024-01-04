using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Nineteenth
{
    public class Nineteenth_01
    {
        public Nineteenth_01()
        {
            Console.WriteLine("19-1");

            List<string> allLines = File.ReadAllLines(".\\input19.txt").ToList();

            long total = 0;

            List<Workflow> workflows = new List<Workflow>();
            List<Rating> ratings = new List<Rating>();

            bool shouldAddToRatings = false;
            foreach (string line in allLines)
            {
                if (line.Equals(""))
                {
                    shouldAddToRatings = true;
                    continue;
                }

                if (!shouldAddToRatings)
                {
                    workflows.Add(new Workflow(line));
                    continue;
                }
                else
                {
                    ratings.Add(new Rating(line));
                }
            }

            foreach (Rating rating in ratings)
            {
                string checkName = "in";
                while (checkName != "A" && checkName != "R")
                {
                    foreach (Workflow workflow in workflows)
                    {
                        if (workflow.name.Equals(checkName))
                        {
                            for (int i = 0; i < workflow.conditions.Count; i++)
                            {
                                if (i ==  workflow.conditions.Count - 1)
                                {
                                    checkName = workflow.conditions[i];
                                }
                                else
                                {
                                    string[] condition = workflow.conditions[i].Split(char.Parse(":"));
                                    string[] conditionValues = condition[0].Replace("<", ",<,").Replace(">", ",>,").Split(char.Parse(","));

                                    int ratingToCheck = 0;
                                    switch (conditionValues[0])
                                    {
                                        case "x":
                                            ratingToCheck = rating.x;
                                            break;
                                        case "m":
                                            ratingToCheck = rating.m;
                                            break;
                                        case "a":
                                            ratingToCheck = rating.a;
                                            break;
                                        case "s":
                                            ratingToCheck = rating.s;
                                            break;
                                    }

                                    if (conditionValues[1].Contains("<"))
                                    {
                                        if (ratingToCheck < int.Parse(conditionValues[2]))
                                        {
                                            checkName = condition[1];
                                            break;
                                        }
                                    }
                                    if (conditionValues[1].Contains(">"))
                                    {
                                        if (ratingToCheck > int.Parse(conditionValues[2]))
                                        {
                                            checkName = condition[1];
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (checkName.Equals("A"))
                {
                    total += rating.x;
                    total += rating.m;
                    total += rating.a;
                    total += rating.s;
                }
                checkName = "in";
            }
            Console.WriteLine(total);
        }
    }
}
