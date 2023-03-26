using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versions
{
    internal class DeconstructClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public DeconstructClass(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public void Deconstruct(out string name, out string address)
        {
            name = Name;
            address = Address;
        }

    }
}
