using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versions
{
    internal class OutParameterEnhance:IDisposable
    {
        public static void takeOutParameter(out string userName,out string password)
        {
            userName = "admin";
            password = "1344343";
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        ~OutParameterEnhance()
        {
            Console.WriteLine("object destroyed");
        }
        /* public static dynamic returndynamic()
{
    return (1, 2,3,4);
}*/
    }
}
