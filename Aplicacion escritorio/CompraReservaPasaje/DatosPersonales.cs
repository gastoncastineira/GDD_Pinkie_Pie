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
using FrbaCrucero.model;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class DatosPersonales : Form
    {
        private string IdPuertoOrigen, IdPuertoDestino;
        private Viaje ViajeElegido;
        private int CantidadDePasajes;
        private double PrecioTotal;
        private Conexion conexion = new Conexion();

        public DatosPersonales(int cantPasajes, Viaje viaje, string idPuertoOrigen, string idPuertoDestino, double precioTotal) : base()
        {
            CantidadDePasajes = cantPasajes;
            ViajeElegido = viaje;
            IdPuertoOrigen = idPuertoOrigen;
            IdPuertoDestino = idPuertoDestino;
            PrecioTotal = precioTotal;

            InitializeComponent();
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;

                if (new MedioDePago(CantidadDePasajes, ViajeElegido, IdPuertoOrigen, IdPuertoDestino, GetCliente(), PrecioTotal).ShowDialog() == DialogResult.OK)
                    DialogResult = DialogResult.OK;
                else
                    Visible = true;
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Cliente GetCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Id = GetIdCliente();

            if (cliente.Id != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", cliente.Id.ToString()));

                List<string> campos = new List<string>();
                campos.Add("nombre");
                campos.Add("apellido");
                campos.Add("DNI");
                campos.Add("direccion");
                campos.Add("telefono");
                campos.Add("mail");
                campos.Add("fecha_nacimiento");

                Dictionary<string, List<object>> cli = conexion.ConsultaPlana(Tabla.Cliente, campos, filtros);

                cliente.Nombre = cli["nombre"].First().ToString();
                cliente.Apellido = cli["apellido"].First().ToString();
                cliente.Dni = Convert.ToInt32(cli["DNI"].First());
                cliente.Direccion = cli["direccion"].First().ToString();
                cliente.Telefono = Convert.ToInt32(cli["telefono"].First());
                cliente.Mail = cli["mail"].First().ToString();
                cliente.FechaDeNacimiento = Convert.ToDateTime(cli["fecha_nacimiento"].First());
            }
            else
            {
                cliente.FechaDeNacimiento = dtFechaDeNacimiento.Value;
                cliente.Telefono = Convert.ToInt32(txtTelefono.Text);
                cliente.Nombre = txtNombre.Text.ToString();
                cliente.Apellido = txtApellido.Text.ToString();
                cliente.Dni = Convert.ToInt32(txtDNI.Text);
                cliente.Direccion = txtDireccion.Text.ToString();
                cliente.Mail = txtMail.Text.ToString();
            }

            return cliente;
        }

        private void TxtDNI_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDNI.Text))
            {
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
            }
        }

        private int CantClientesConMismoDNI()
        {
            if (ValidarSoloNumeros(txtDNI.Text, "DNI") == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("DNI", txtDNI.Text.ToString().Trim()));

                Dictionary<string, List<object>> cantIdsConEseDNI = conexion.ConsultaPlana(Tabla.Cliente, new List<string>(new string[] { "COUNT(ID) AS cantidad" }), filtros);

                return Convert.ToInt16(cantIdsConEseDNI["cantidad"].First());
            }

            return -1;
        }

        private int GetIdCliente()
        {
            int cantClienteConMismoDNI = CantClientesConMismoDNI();
            if (cantClienteConMismoDNI != 0 && cantClienteConMismoDNI != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("DNI", txtDNI.Text.ToString().Trim()));
                filtros.Add(FiltroFactory.Libre("nombre", txtNombre.Text.ToString()));
                filtros.Add(FiltroFactory.Libre("apellido", txtApellido.Text.ToString()));

                if (conexion.ExisteRegistro(Tabla.Cliente, new List<string>(new string[] { "ID" }), filtros))
                {
                    Dictionary<string, List<object>> cliente = conexion.ConsultaPlana(Tabla.Cliente, new List<string>(new string[] { "ID" }), filtros);

                    return Convert.ToInt32(cliente["ID"].First());
                }
            }

            return -1;
        }

        private void BtnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtNombre.Text = null;
            txtApellido.Text = null;
            txtDireccion.Text = null;
            txtTelefono.Text = null;
            txtMail.Text = null;
            txtNombre.Text = null;
        }

        // ---------------------------------------VALIDACIONES------------------------------------------
        private String ValidarCampos() 
        {
            String resultado = "";

            resultado += this.ValidarCamposVacios();

            // DNI
            resultado += this.ValidarSoloNumeros(txtDNI.Text, "DNI");

            // Nombre
            resultado += this.ValidarSoloLetras(txtNombre.Text, "nombre");

            // Apellido
            resultado += this.ValidarSoloLetras(txtApellido.Text, "apellido");

            // Teléfono
            resultado += this.ValidarSoloNumeros(txtTelefono.Text, "teléfono");

            // Mail
            resultado += this.ValidarEsMail(txtMail.Text);

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
                if (!(char.IsLetter(letra) || char.IsWhiteSpace(letra)))
                    return "En el campo " + tipoDeCampo + " solo se pueden ingresar letras. \n";
            }

            return "";
        }

        private String ValidarEsMail(String texto)
        {
            if (!string.IsNullOrEmpty(txtMail.Text))
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

            return "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}