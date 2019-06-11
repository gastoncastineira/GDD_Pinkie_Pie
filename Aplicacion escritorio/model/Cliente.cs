using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.model
{
    public class Cliente
    {
        public int Id { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }

    }
}
