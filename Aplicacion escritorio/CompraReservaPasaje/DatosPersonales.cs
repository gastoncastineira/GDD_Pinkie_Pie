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
        private int CantidadDePasajes, PrecioTotal;
        private Conexion conexion = new Conexion();

        public DatosPersonales(int cantPasajes, Viaje viaje, string idPuertoOrigen, string idPuertoDestino, int precioTotal)
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
            this.Visible = false;
            new SeleccionarViaje(ViajeElegido.FechaInicio, IdPuertoOrigen, IdPuertoDestino).Show();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;

                new MedioDePago(CantidadDePasajes, ViajeElegido, IdPuertoOrigen, IdPuertoDestino, getCliente(), PrecioTotal, RecorridoId).Show();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Cliente getCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Id = getIdCliente();

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
                cliente.Dni = Convert.ToInt32(cli["nombre"].First());
                cliente.Direccion = cli["direccion"].First().ToString();
                cliente.Telefono = Convert.ToInt32(cli["telefono"].First());
                cliente.Mail = cli["mail"].First().ToString();
                cliente.FechaDeNacimiento = Convert.ToDateTime(cli["telefono"].First());
            }

            return cliente;
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
        }

        private int CantClientesConMismoDNI()
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("DNI", txtDNI.Text.ToString().Trim()));

            Dictionary<string, List<object>> cantIdsConEseDNI = conexion.ConsultaPlana(Tabla.Cliente, new List<string>(new string[] { "COUNT(ID) AS cantidad" }), filtros);

            return Convert.ToInt16(cantIdsConEseDNI["cantidad"].First());
        }

        private int getIdCliente()
        {
            if (CantClientesConMismoDNI() != 0)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("DNI", txtDNI.Text.ToString().Trim()));
                filtros.Add(FiltroFactory.Libre("nombre", txtNombre.Text.ToString()));
                filtros.Add(FiltroFactory.Libre("apellido", txtApellido.Text.ToString()));

                Dictionary<string, List<object>> cliente = conexion.ConsultaPlana(Tabla.Cliente, new List<string>(new string[] { "ID" }), filtros);

                return Convert.ToInt16(cliente["ID"].First());
            }

            return -1;
        }

        private void BtnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtDNI.Text = null;
            txtNombre.Text = null;
            txtApellido.Text = null;
            txtDireccion.Text = null;
            txtTelefono.Text = null;
            txtMail.Text = null;
            txtNombre.Text = null;
        }

        // ---------------------------------------VALIDACIONES------------------------------------------
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

            // No puede hacer compras sobre viajes pasados.
            resultado += this.ValidarSiYaComproEseViaje();

            // No puede viajar a más de un destino a la vez
            resultado += this.ValidarSiHayMasDeUnDestino();

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
            int idCliente = getIdCliente();
            if (idCliente != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("cliente_id", idCliente.ToString()));
                filtros.Add(FiltroFactory.Exacto("viaje_id", ViajeElegido.Id.ToString()));

                return conexion.ExisteRegistro(Tabla.ClienteComproViaje, new List<string>(new string[] { "cliente_id" }), filtros);
            }

            return false;
        }

        private bool TieneUnaReservaConViajePorComprar()
        {
            int idCliente = getIdCliente();
            if (idCliente != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("cliente_id", idCliente.ToString()));
                filtros.Add(FiltroFactory.Exacto("viaje_id", ViajeElegido.Id.ToString()));

                return conexion.ExisteRegistro(Tabla.ClienteReservoViaje, new List<string>(new string[] { "cliente_id" }), filtros);
            }

            return false;
        }

        private string ValidarSiHayMasDeUnDestino()
        {
            int idCliente = getIdCliente();
            if (idCliente != -1)
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("cliente_id", idCliente.ToString()));
                filtros.Add(FiltroFactory.Exacto("fecha_inicio", ViajeElegido.FechaInicio.ToString("yyyy-MM-dd")));

                if (conexion.ExisteRegistro(Tabla.ClienteReservoViaje, new List<string>(new string[] { "cliente_id" }), filtros))
                    return "No puede viajar a más de un destino a la vez.\n";
            }
            return "";
        }

    }
}