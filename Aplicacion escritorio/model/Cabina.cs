using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.model
{
    class Cabina
    {
        public int Id { get; }
        public int Crucero_id { get; set; }
        public int Viaje_id { get; set; }
        public int Pasaje_id { get; set; }
        public int Reserva_id { get; set; }
        public int Tipo_id { get; set; }
        public int NumeroPiso { get; set; }
        public Boolean Ocupado { get; set; }

        public Cabina(int id, int crucero, int viaje, int nroPiso, Boolean ocupado)
        {
            Id = id;
            Crucero_id = crucero;
            Viaje_id = viaje;
            NumeroPiso = nroPiso;
            Ocupado = ocupado;
        }
    }
}
