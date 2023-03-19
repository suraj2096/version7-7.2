using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versions
{
    public class ExpressionBodedMembers
    {
        
       public string Name { get; set; }

        // expression bodided for constructor
        public ExpressionBodedMembers(string name) => Name = name;

        public string getName() => $"the name is {Name}";

        public  string readData
        {
            get => Name;
            set => Name = value;

        }
    }
}
