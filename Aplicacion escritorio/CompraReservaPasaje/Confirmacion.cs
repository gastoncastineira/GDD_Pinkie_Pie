using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class Confirmacion : Form // TODO hacer vista compra o reserva segun corresponda
    {
        private String CantidadDePasajes;
        public Confirmacion(String cantPasajes)
        {
            InitializeComponent();
            this.CantidadDePasajes = cantPasajes;
        }

        private void Confirmacion_Load(object sender, EventArgs e)
        {
            lblCantidadDePasajeros.Text = "Cantidad de pasajeros: " + this.CantidadDePasajes;
            // TODO numero, fecha de inicio, fecha de finalizacion, recorridos, crucero y tipo de cabina.
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //new DatosPersonales(this.CantidadDePasajes).Show();
            new DatosPersonales().Show();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try // ver si va
            {
                // TODO poner en la bd en tabla Viaje pasajesVendidos += this.CantidadDePasajes
                // crear un pasaje o Reserva segun corresponda?
                // si antes no existia el usuario agregarlo a la bd
                // marcar a la cabina como ocupada


                MessageBox.Show("Se ha hecho la compra correctamente!", "Compra confirmada");

            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message, "Error");
            }



        }

        
    }
}