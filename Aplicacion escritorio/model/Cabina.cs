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
        public int Tipo_id { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroHabitacion { get; set; }
        public Boolean Ocupado { get; set; }

        public Cabina(int crucero, int viaje, int tipo_id, int nroPiso, int nroHabitacion, Boolean ocupado)
        {
            Crucero_id = crucero;
            Viaje_id = viaje;
            Tipo_id = tipo_id;
            NumeroPiso = nroPiso;
            NumeroHabitacion = nroHabitacion;
            Ocupado = ocupado;
        }
    }
}
