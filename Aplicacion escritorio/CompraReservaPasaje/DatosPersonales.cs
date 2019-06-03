using Conexiones;
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
        private Conexion conexion = new Conexion();

        public DatosPersonales(String cantPasajes)
        {
            InitializeComponent();
            this.CantidadDePasajes = cantPasajes;
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
            if (CantClientesConMismoDNI() == 1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("DNI", txtDNI.Text.Trim()));

                List<string> campos = new List<string>();
                campos.Add("nombre");
                campos.Add("apellido");
                campos.Add("direccion");
                campos.Add("telefono");
                campos.Add("mail");
                campos.Add("fecha_nacimiento");

                Dictionary<string, List<object>> cliente = conexion.ConsultaPlana(Tabla.Cliente, campos, filtros);

                txtNombre.Text = cliente["nombre"].First().ToString();
                txtApellido.Text = cliente["apellido"].First().ToString();
                txtDireccion.Text = cliente["direccion"].First().ToString();
                txtTelefono.Text = cliente["telefono"].First().ToString();
                txtMail.Text = cliente["mail"].First().ToString();
                txtNombre.Text = cliente["nombre"].First().ToString();
                dtFechaDeNacimiento.Value = Convert.ToDateTime(cliente["fecha_nacimiento"].First());
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

        private int CantClientesConMismoDNI()
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("DNI", txtDNI.Text.Trim()));

            Dictionary<string, List<object>> cantIdsConEseDNI = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "COUNT(DISTINCT ID) AS cantidad" }), filtros);

            return Convert.ToInt16(cantIdsConEseDNI["cantidad"].First());
        }

        // VALIDACIONES
        private String ValidarCampos() // TODO
        {
            String resultado = "";

            resultado += this.ValidarCamposVacios();

            // DNI
            resultado += this.ValidarSoloNumeros(txtDNI.Text, "DNI");

            // Nombre
            resultado += this.ValidarSoloLetras(txtDNI.Text, "nombre");

            // Apellido
            resultado += this.ValidarSoloLetras(txtDNI.Text, "apellido");

            // Teléfono
            resultado += this.ValidarSoloNumeros(txtTelefono.Text, "teléfono");

            // Mail
            resultado += this.ValidarEsMail(txtTelefono.Text);

            // Método de pago
            // validar que no este vacio

            // no puede hacer compras sobre viajes pasados.
            resultado += this.ValidarSiYaComproEseViaje();

            return resultado;
        }

        // VALIDACIONES
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

        private String ValidarSoloNumeros(String texto, String tipoDeCampo)
        {
            foreach (char letra in texto.Trim())
            {
                if (!char.IsNumber(letra))
                    return "En el campo " + tipoDeCampo + " solo se pueden ingresar numeros. \n";
            }

            return "";
        }

        private String ValidarSoloLetras(String texto, String tipoDeCampo)
        {
            foreach (char letra in texto.Trim())
            {
                if (!char.IsLetter(letra))
                    return "En el campo " + tipoDeCampo + " solo se pueden ingresar letras. \n";
            }

            return "";
        }

        private String ValidarEsMail(String texto)
        {
            int cantArroba = 0;
            foreach (char letra in texto.Trim())
            {
                if (letra == '@')
                    cantArroba++;
            }

            if (cantArroba == 1)
                return "";

            return "En el campo mail tiene que ingresar una direccion email válida.\n";
        }

        private String ValidarSiYaComproEseViaje()
        {
            if (TieneUnPasajeConViajePorComprar() || TieneUnaReservaConViajePorComprar())
                return "No se puede hacer compras sobre viajes pasados.\n";

            return "";
        }

        private bool TieneUnPasajeConViajePorComprar()
        {
            int cantClientesConMismoDNI = CantClientesConMismoDNI();
            if (cantClientesConMismoDNI >= 1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("DNI", txtDNI.ToString()));
                filtros.Add(FiltroFactory.Libre("nombre", txtNombre.ToString()));
                filtros.Add(FiltroFactory.Libre("apellido", txtNombre.ToString()));

                Dictionary<string, List<object>> clienteConMismoDNI = conexion.ConsultaPlana(Tabla.Cliente, new List<string>(new string[] { "ID" }), filtros);

                // Este es el caso en el que una persona tiene el mismo DNI que un cliente anterior pero no es cliente nuestro
                if (clienteConMismoDNI["ID"].First() == null)
                    return false;

                int idCliente = Convert.ToInt16(clienteConMismoDNI["ID"].First());

                // ME QUEDE ACA
                // TODO seguir, ver si el cliente ya tiene un pasaje con ese viaje

                return true;
            }

            return false;
        }

        private bool TieneUnaReservaConViajePorComprar()
        {
            return false;
        }
    }
}