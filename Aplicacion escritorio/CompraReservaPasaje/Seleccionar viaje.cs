using FrbaCrucero.CompraPasaje;
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
    public partial class SeleccionarViaje : Form
    {
        private String CantidadDePasajes;

        public SeleccionarViaje(String cantPasajes)
        {
            InitializeComponent();
            this.CantidadDePasajes = cantPasajes;
        }

        private void SeleccionarViaje_Load(object sender, EventArgs e)
        {
            // Load list  TODO LlenarLista al final va a ser una data grid view
            LlenarDataGridViajes();
            
        }

        private void LlenarDataGridViajes()
        {
            // TODO no se me ocurre ahora cómo hacerlo
            /*
             *
             SELECT v.fechaInicio, v.fechaFinalizacion, c.marca 
             FROM Viaje v
             JOIN Cabina ca
                ON ca.viaje_id = v.id
             JOIN Crucero cru
                ON cru.id = ca.crucero_id
             WHERE (c.bajaPorFueraDeServicio == false && c.bajaPorVidaUtil == false)
             */
            // recorridos, precio TODO

        }

        private void BtnPrimerPagina_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnUltimaPagina_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ComprarReservarViaje().Show();
        }



        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;
                new DatosPersonales(this.CantidadDePasajes).Show();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // VALIDACIONES
        private String ValidarCampos()
        {
            // Validar que selecciono un campo TODO ver video
            return "";
        }
    }
}
