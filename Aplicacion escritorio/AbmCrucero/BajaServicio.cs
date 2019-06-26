using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexiones;

namespace FrbaCrucero.AbmCrucero
{
    public partial class BajaServicio : Form
    {

        private Conexion conexion = new Conexion();
        private List<int> idsFueraServ = new List<int>();

        public BajaServicio(List<int> _idsFueraServ)
        {
            this.idsFueraServ = _idsFueraServ;
            InitializeComponent();
        }

        private void BajaServicio_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = ConfigurationHelper.FechaActual;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime fechaActual = ConfigurationHelper.FechaActual;
            DateTime fechaVuelta = dateTimePicker1.Value;

            if (DateTime.Equals(fechaActual,fechaVuelta))
            {
                MessageBox.Show("No puede usarse la misma fecha de alta que de baja", "Error fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Transaccion trans = conexion.IniciarTransaccion();
                foreach (int id in this.idsFueraServ)
                {

                    Dictionary<string, object> modificacion = new Dictionary<string, object>();
                    modificacion.Add("baja_fuera_de_servicio", true);
                    conexion.Modificar(id, Tabla.Crucero, modificacion);

                    Dictionary<string, object> insert = new Dictionary<string, object>();
                    insert.Add("fecha_fuera_de_servicio", fechaActual);
                    insert.Add("fecha_reinicio_servicio", fechaVuelta);
                    insert.Add("id_crucero", id);
                 
                    trans.Insertar(Tabla.FechaFueraServicio, insert);                  

                    conexion.CancelarPasajes(id, fechaActual, fechaVuelta);

                }
                trans.Commit();
                MessageBox.Show("Baja dada exitosamente");
                DialogResult = DialogResult.OK;

            }

        }

    }
}
