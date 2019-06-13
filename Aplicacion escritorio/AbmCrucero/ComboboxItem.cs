using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.AbmCrucero
{
    class ComboboxItem
    {

        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
