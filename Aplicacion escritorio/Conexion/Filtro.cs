using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Conexion
{
    public class Filtro
    {
        public Filtro(string col, string condicion)
        {
            Columna = col;
            Condicion = condicion;
        }

        public string Columna { get; }
        public string Condicion { get; }
    }
}
