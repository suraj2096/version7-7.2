using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versions
{
    public class PattenMatching7
    {
        public class Figure
        {

        }
        public class Square:Figure { 
           public double Length { get; set; }
        }
        public class Rectangle : Figure
        {
            public double Length { get; set; }
            public double Breadth { get; set; }

            public  void Deconstruct(out double length,out double breadth)
            {
                length = Length;
                breadth = Breadth;
            }
        }
        public class Circle:Figure
        {
            public double Radius { get; set; }
        }

    }
}
