using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Seventh
{
    public class HandValues
    {
        public int _cards;
        public int _betValue;
        public HandValues(List<int> cards, int betValue) 
        {
            string _total = string.Empty;
            foreach (var card in cards)
            {
                if (card >= 10)
                {
                    _total += card;
                }
                else
                {
                    _total += "0" + card;
                }
            }
            _cards = int.Parse(_total);
            _betValue = betValue;
        }
    }
}
