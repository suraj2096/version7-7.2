using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versions
{
    public class PrivateProtectedDemo
    {

       
    }
    public class Parent
    {
        private protected void Message()
        {
            Console.WriteLine("this is the parent message!!!");
        }
    }
    public class Child1:Parent
    {
        public void callParent()
        {
            Message();
        }
    }
}
