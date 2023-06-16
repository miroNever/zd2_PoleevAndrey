using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poleev_Pr2
{
    class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        internal Contact (string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
