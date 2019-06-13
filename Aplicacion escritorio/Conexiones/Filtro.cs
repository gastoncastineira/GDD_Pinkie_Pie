using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    public class Filtro
    {
        public Filtro(string col, string condicion)
        {
            Columna = col;
            Condicion = condicion;
        }

        internal string Columna { get; set; }
        internal string Condicion { get; set;}
    }
}
