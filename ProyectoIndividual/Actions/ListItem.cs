using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoIndividual.Actions
{
    class ListItem
    {
        public String Name { get; set; }
        public Object Value { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
