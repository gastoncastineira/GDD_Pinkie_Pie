using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.CompraReservaPasaje;
using FrbaCrucero.model;

namespace FrbaCrucero.CompraPasaje
{
    public partial class ComprarReservarViaje : Form
    {
        private int Recorrido_id;
        private List<Viaje> Viajes = new List<Viaje>();
        public ComprarReservarViaje()
        {
            InitializeComponent();
        }

        private void ComprarReservarViaje_Load(object sender, EventArgs e)
        {
            AutoCompletarDestino(txtDestino);

        }

        public void AutoCompletarDestino(TextBox cajaTexto) // hacer idem con origen TODO
        {
            //  ver https://www.youtube.com/watch?v=PTod0kV91Xs
            /* 
            SELECT descripcion FROM Puerto 
            WHERE (descripcion LIKE ('%" + cajaTexto.Text.Trim() + "%')) && descripcion != txtOrigen.Text 
             */

        }

        private void BtnBuscarViajes_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                if (HayViajes())
                {
                    this.Visible = false;
                    new SeleccionarViaje(txtCantidadPasajes.Text).Show();
                }
                else
                {
                    MessageBox.Show("No hay viajes para los campos seleccionados.\n", "No hay viajes", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HayViajes() // TODO
        {
            return true;
        }


        // VALIDACIONES
        private String ValidarCampos() // TODO
        {
            String resultado = "";

            resultado += this.ValidarCamposVacios();

            // PUERTO ORIGEN
            resultado = ValidarExistenciaPuerto(txtOrigen.Text, "origen");

            // PUERTO DESTINO
            resultado = ValidarExistenciaPuerto(txtDestino.Text, "destino");

            //  A PASAJES A COMPRAR
            // validar de que sea un entero

            return resultado;
        }

        private String ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtOrigen.Text) || string.IsNullOrEmpty(txtDestino.Text) || string.IsNullOrEmpty(txtCantidadPasajes.Text))
            {
                return "Se detecto un campo vacio. Revise. \n";
            }

            return "";
        }

        private String ValidarExistenciaPuerto(String puerto, String tipoPuerto)
        {
            try // TODO ver si es try catch o if else, no tengo seguro este tema
            {
                String puertoExiste;
                /* TODO debe estar mal esto
                 puertoExiste = 
                 SELECT descripcion FROM Puerto WHERE descripcion == puerto
                 
                 */

                return "";
            }
            catch (Exception error)
            {
                return "El puerto " + tipoPuerto + " no existe.\n";
            }
        }
    }
}