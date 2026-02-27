using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2_Zuev
{
    class company
    {
        public class Department
        {
            public string Name { get; set; }
            public string Reg { get; set; }
        }

        public class Employ
        {
            public string Name { get; set; }
            public string department { get; set; }
        }
    }
}
