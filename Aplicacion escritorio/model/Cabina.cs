using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.model
{
    class Cabina
    {
        private int Id { get;  }
        public int Crucero_id { get; set; }
        public int Viaje_id { get; set; }
        private int Pasaje_id { get; set; }
        private int Reserva_id { get; set; }
        private String Servicio { get; set; }
        private String Descripcion { get; set; }
        private int PorcentajeCosto { get; set; }
        private Boolean Ocupado { get; set; }


        public Cabina(int id, int crucero_id, int viaje_id, Boolean ocupado)
        {
            Id = id;
            Crucero_id = crucero_id;
            Viaje_id = viaje_id;
            Ocupado = ocupado;
        }

    }
}
