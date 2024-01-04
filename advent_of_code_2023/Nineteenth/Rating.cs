using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Linq;

namespace advent_of_code_2023.Nineteenth
{
    public class Rating
    {
        public int x;
        public int m;
        public int a;
        public int s;
        public Rating(string line) 
        {
            string values = "";
            foreach (char character in line) 
            {
                if (!char.IsNumber(character) && !character.Equals(char.Parse(","))) continue;
                values += character;
            }
            x = int.Parse(values.Split(char.Parse(","))[0]);
            m = int.Parse(values.Split(char.Parse(","))[1]);
            a = int.Parse(values.Split(char.Parse(","))[2]);
            s = int.Parse(values.Split(char.Parse(","))[3]);
        }
    }
}
