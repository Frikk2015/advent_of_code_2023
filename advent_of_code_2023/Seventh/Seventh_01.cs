using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Seventh
{
    public class Seventh_01
    {
        public Seventh_01() 
        {
            Console.WriteLine("7-1");
            string[] allLines = File.ReadAllLines("./input7.txt");
            long total = 0;

            List<HandValues> handValues = new List<HandValues>();

            List<HandValues> fiveOfAKind = new List<HandValues>();
            List<HandValues> fourOfAKind = new List<HandValues>();
            List<HandValues> fullHouse = new List<HandValues>();
            List<HandValues> threeOfAKind = new List<HandValues>();
            List<HandValues> twoPairs = new List<HandValues>();
            List<HandValues> onePair = new List<HandValues>();
            List<HandValues> highCard = new List<HandValues>();

            List<string> cards = new List<string>{"2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"};

            foreach (string line in allLines)
            {
                string[] values = line.Split(" ".ToCharArray()[0]);

                List<int> matchingHands = new List<int>();

                foreach (string card in cards)
                {
                    matchingHands.Add(values[0].Count(n => n == char.Parse(card)));
                }

                bool canThreeBeFullHouse = false;
                bool canTwoBeFullHouse = false;
                bool canBeTwoPairs = false;
                bool canBeOnePair = false;
                bool canBeThreeOfAKind = false;
                bool canBeHighCard = true;

                foreach (int matchingHand in matchingHands)
                {
                    if (matchingHand.Equals(5))
                    {
                        fiveOfAKind.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                        canBeHighCard = false;
                        Console.WriteLine("Five of a kind");
                        break;
                    }
                    else if (matchingHand.Equals(4))
                    {
                        fourOfAKind.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                        canBeHighCard = false;
                        Console.WriteLine("Four of a kind");
                        break;
                    }
                    else if (matchingHand.Equals(3))
                    {
                        if (canThreeBeFullHouse)
                        {
                            canBeOnePair = false;
                            break;
                        }
                        else
                        {
                            canTwoBeFullHouse = true;
                            canBeThreeOfAKind = true;
                        }
                    }
                    else if (matchingHand.Equals(2))
                    {
                        if (canTwoBeFullHouse)
                        {
                            canBeOnePair = false;
                            canBeThreeOfAKind = false;
                            canBeTwoPairs = false;
                            break;
                        }
                        else if (canBeTwoPairs)
                        {
                            canBeOnePair = false;
                            canBeThreeOfAKind = false;
                            canThreeBeFullHouse = false;
                            break;
                        }
                        else
                        {
                            canBeOnePair = true;
                            canThreeBeFullHouse = true;
                            canBeTwoPairs = true;
                        }
                    }
                }
                if (canBeOnePair)
                {
                    onePair.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                    Console.WriteLine("One pair");
                }
                else if (canBeThreeOfAKind)
                {
                    threeOfAKind.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                    Console.WriteLine("Three of a kind");
                }
                else if (canThreeBeFullHouse || canTwoBeFullHouse)
                {
                    fullHouse.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                    Console.WriteLine("Full house");
                }
                else if (canBeTwoPairs)
                {
                    twoPairs.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                    Console.WriteLine("Two pairs");
                }
                else if (canBeHighCard)
                {
                    highCard.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                    Console.WriteLine("High card");
                }
            }
            Console.WriteLine("High card: " + highCard[0]._cards.Count() / 5);
            Console.WriteLine("Two pairs: " + twoPairs.Count() / 5);
            Console.WriteLine("Three of a kind: " + threeOfAKind.Count() / 5);
            Console.WriteLine("Full house: " + fullHouse.Count() / 5);
            Console.WriteLine("Four of a kind: " + fourOfAKind.Count() / 5);
            Console.WriteLine("Five of a kind: " + fiveOfAKind.Count() / 5);

            for (int i = 0; i < fiveOfAKind.Count(); i+= 5)
            {

            }
        }
        public List<int> GetValue(string cards)
        {
            List<int> values = new List<int>();
            foreach (char card in cards)
            {
                switch (card)
                {
                    case 'A':
                        values.Add(14);
                        break;
                    case 'K':
                        values.Add(13);
                        break;
                    case 'Q':
                        values.Add(12);
                        break;
                    case 'J':
                        values.Add(11);
                        break;
                    case 'T':
                        values.Add(10);
                        break;
                    default:
                        values.Add(int.Parse(card.ToString()));
                        break;
                }
            }
            return values;
        }
    }
}
