using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.model
{
    public class Viaje
    {
        public int Id { get; set; }
        public int Recorrido_id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime Fecha_Fin_Estimada { get; set; }
        public int PasajesVendidos { get; set; }

        public List<Cabina> Cabinas;

        public Viaje() { }
    }
}
