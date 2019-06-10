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

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoReserva : FormTemplate
    {
        public PagoReserva():base()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Debe ingresar un ID");
                return;
            }
            Conexion con = new Conexion();
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("ID", txtID.Text));
            List<string> col = new List<string>();
            col.Add("cliente_id");
            col.Add("fecha_de_reserva");
            col.Add("cabina_id");
            col.Add("medio_de_pago_id");
            col.Add("precio");
            Dictionary<string, List<object>> resul = con.ConsultaPlana(Tabla.Reserva, col, filtros);
            if (resul["precio"].Count == 0)
            {
                MessageBox.Show("No se encontro reserva con ese ID");
                return;
            }
            DateTime fecha = Convert.ToDateTime(resul["fecha_de_reserva"][0]);
            TimeSpan dif = ConfigurationHelper.FechaActual.Subtract(fecha);
            if (dif.Days > 3)
            {
                MessageBox.Show("Esa reserva se encuentra vencida");
                return;
            }
            Dictionary<string, object> valores = new Dictionary<string, object>();
            valores["cliente_id"] = resul["cliente_id"][0];
            valores["fecha_de_compra"] = resul["fecha_de_reserva"][0];
            valores["cabina_id"] = resul["cabina_id"][0];
            valores["medio_de_pago_id"] = resul["medio_de_pago_id"][0];
            valores["precio"] = resul["precio"][0];
            if (MessageBox.Show("El precio total es de " + resul["precio"][0].ToString() + "\n¿Desea continuar?", "confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (con.Insertar(Tabla.Pasaje, valores) != -1)
                    MessageBox.Show("Se pago el pasaje exitosamente");
                else
                    MessageBox.Show("Hubo un error, intente de nuevo más tarde");
            }
            else
                MessageBox.Show("Se cancelo la operacion");
        }
    }
}
