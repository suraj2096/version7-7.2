using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versions
{
    public class ReadonlyProperty
    {
        public readonly string Name;
        public  int Age { get; }
        public ReadonlyProperty(string name, int age)
        {
            Name = name; Age = age;
        }



    }
}
