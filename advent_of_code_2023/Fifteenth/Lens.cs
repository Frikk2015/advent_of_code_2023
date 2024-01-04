using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Fifteenth
{
    public class Lens
    {
        public string label;
        public int value;
        public Lens(string label, int value) 
        {
            this.label = label;
            this.value = value;
        }
    }
}
