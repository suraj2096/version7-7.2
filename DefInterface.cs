using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versions
{
     public interface DefInterface
    {
        public string call();
        public void DefaultMessage()
        {
            Console.WriteLine("Hello Sir");
        }
    }
}
