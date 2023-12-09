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

            List<RankBetValues> rankBetValues = new List<RankBetValues>();

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
                        break;
                    }
                    else if (matchingHand.Equals(4))
                    {
                        fourOfAKind.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                        canBeHighCard = false;
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
                }
                else if (canBeThreeOfAKind)
                {
                    threeOfAKind.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                }
                else if (canThreeBeFullHouse || canTwoBeFullHouse)
                {
                    fullHouse.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                }
                else if (canBeTwoPairs)
                {
                    twoPairs.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                }
                else if (canBeHighCard)
                {
                    highCard.Add(new HandValues(GetValue(values[0]), int.Parse(values[1])));
                }
            }

            fiveOfAKind = fiveOfAKind.OrderBy(card => card._cards).ToList();
            fourOfAKind = fourOfAKind.OrderBy(card => card._cards).ToList();
            fullHouse = fullHouse.OrderBy(card => card._cards).ToList();
            threeOfAKind = threeOfAKind.OrderBy(card => card._cards).ToList();
            twoPairs = twoPairs.OrderBy(card => card._cards).ToList();
            onePair = onePair.OrderBy(card => card._cards).ToList();
            highCard = highCard.OrderBy(card => card._cards).ToList();

            int previousRank = 1;

            foreach (HandValues card in highCard)
            {
                rankBetValues.Add(new RankBetValues(previousRank, card._betValue));
                previousRank++;
            }
            foreach (HandValues card in onePair)
            {
                rankBetValues.Add(new RankBetValues(previousRank, card._betValue));
                previousRank++;
            }
            foreach (HandValues card in twoPairs)
            {
                rankBetValues.Add(new RankBetValues(previousRank, card._betValue));
                previousRank++;
            }
            foreach (HandValues card in threeOfAKind)
            {
                rankBetValues.Add(new RankBetValues(previousRank, card._betValue));
                previousRank++;
            }
            foreach (HandValues card in fullHouse)
            {
                rankBetValues.Add(new RankBetValues(previousRank, card._betValue));
                previousRank++;
            }
            foreach (HandValues card in fourOfAKind)
            {
                rankBetValues.Add(new RankBetValues(previousRank, card._betValue));
                previousRank++;
            }
            foreach (HandValues card in fiveOfAKind)
            {
                rankBetValues.Add(new RankBetValues(previousRank, card._betValue));
                previousRank++;
            }
    
            foreach (RankBetValues result in rankBetValues)
            {
                total += result._betValue * result._rank;
            }

            Console.WriteLine(total);
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
