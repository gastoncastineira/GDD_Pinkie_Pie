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
        public SeleccionarViaje()
        {
            InitializeComponent();
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
                //new DatosPersonales(this.CantidadDePasajes).Show();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // VALIDACIONES
        private String ValidarCampos()
        {
            string resultado = "";

            // Validar que selecciono un campo TODO ver video
            resultado += this.ValidarCamposVacios(); 
            resultado += this.ValidarSoloNumeros(txtCantidadPasajes.Text);
            return "";
        }

        private String ValidarSoloNumeros(String texto)
        {
            foreach (char letra in texto.Trim())
            {
                if (!char.IsNumber(letra))
                    return "En cantidad de pasajes solo se pueden ingresar numeros. \n";
            }

            return "";
        }

        private String ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtCantidadPasajes.Text))
            {
                return "Se detecto un campo vacio. Revise. \n";
            }

            return "";
        }
    }
}