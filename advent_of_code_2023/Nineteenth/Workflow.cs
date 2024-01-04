using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2023.Nineteenth
{
    public class Workflow
    {
        public string name;
        public List<string> conditions;
        public Workflow(string line) 
        { 
            List<string> values = line.Replace("}", "").Split(char.Parse("{")).ToList();
            name = values[0];
            conditions = values[1].Split(char.Parse(",")).ToList();
        }
    }
}
