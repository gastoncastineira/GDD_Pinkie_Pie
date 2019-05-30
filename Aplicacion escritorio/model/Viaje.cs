using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.model
{
    class Viaje
    {
        public int Id { get; set; }
        public int Recorrido_id { get; set; }
        public DateTime FechaInicio { get; set; } //TODO ver tipo de fecha, buscar uno que pueda poner año, mes, día y hora
        public DateTime FechaFinalizacion { get; set; }
        public int PasajesVendidos { get; set; } //TODO ver enunciado nuevo, consultas y el script

        public List<Cabina> Cabinas;

        public Viaje(){}

        // TODO persistir
    }
}
