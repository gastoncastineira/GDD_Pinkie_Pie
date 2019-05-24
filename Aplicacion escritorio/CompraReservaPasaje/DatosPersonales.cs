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
    public partial class DatosPersonales : Form // TODO RESERVA Y METODO DE PAGO
    {
        private String CantidadDePasajes;

        public DatosPersonales(String cantPasajes)
        {
            InitializeComponent();
            this.CantidadDePasajes = cantPasajes;
        }

        public DatosPersonales()
        {
            InitializeComponent();
        }

        private Boolean YaViajo() // TODO
        {
            if (txtDNI.Text == "123")
                return true;
            else
                return false;
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new SeleccionarViaje(this.CantidadDePasajes).Show();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;
                //new Confirmacion(this.CantidadDePasajes).Show();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatosPersonales_Load(object sender, EventArgs e)
        {
            // TODO cargar metodos de pago
        }

        private void TxtDNI_Leave(object sender, EventArgs e)
        {
            // TODO que se rellenen los otros campos automaticamente
            if (YaViajo())
            {
                /*
                 txtNombre.Text = 
                 "SELECT nombre FROM Cliente WHERE dni = " + txtDNI.Text
                 txtApellido.Text = 
                 "SELECT apellido FROM Cliente WHERE dni = " + txtDNI.Text
                 txtDireccion.Text =
                 "SELECT direccion FROM Cliente WHERE dni = " + txtDNI.Text
                 txtTelefono.Text = 
                 "SELECT telefono FROM Cliente WHERE dni = " + txtDNI.Text
                 txtMail.Text =
                 "SELECT mail FROM Cliente WHERE dni = " + txtDNI.Text
                 */
                txtNombre.Text = "Melisa";
                txtApellido.Text = "Rodriguez";
                txtDireccion.Text = "Belaustegui";
                txtTelefono.Text = "4564565";
                txtMail.Text = "melisacapa@hotmail.com";

            }
            else
            {
                txtNombre.Text = null;
                txtApellido.Text = null;
                txtDireccion.Text = null;
                txtTelefono.Text = null;
                txtMail.Text = null;
                txtMail.Text = null;
            }
        }

        // VALIDACIONES
        private String ValidarCampos() // TODO
        {
            // no puede hacer compras sobre viajes pasados.

            String resultado = "";

            resultado += this.ValidarCamposVacios();

            // DNI
            // validar que sean sólo números

            // Nombre
            // validar que sean sólo letras

            // Apellido
            // validar que sean sólo letras

            // Teléfono
            // validar que son solo numeros

            // Mail
            // validar de que sea un mail

            // Fecha de nacimiento
            // validar que sea mayor de edad

            // Método de pago
            // validar que no este vacio

            return resultado;
        }

        private String ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtNombre.Text) 
                || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDireccion.Text) 
                || string.IsNullOrEmpty(txtTelefono.Text))
            {
                return "Se detecto un campo vacio. Revise. \n";
            }

            return "";
        }


    }
}