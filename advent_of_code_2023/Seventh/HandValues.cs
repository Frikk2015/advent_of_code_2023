using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Seventh
{
    public class HandValues
    {
        public List<int> _cards;
        public int _betValue;
        public HandValues(List<int> cards, int betValue) 
        {
            _cards = cards;
            _betValue = betValue;
        }
    }
}
