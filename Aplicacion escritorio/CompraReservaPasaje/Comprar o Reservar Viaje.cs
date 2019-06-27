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
using FrbaCrucero.model;
using FrbaCrucero.CompraReservaPasaje;

namespace FrbaCrucero.CompraPasaje
{
    public partial class ComprarReservarViaje : FormTemplate
    {
        private Conexion conexion = new Conexion();

        public ComprarReservarViaje():base()
        {
            InitializeComponent();
        }

        private void ComprarReservarViaje_Load(object sender, EventArgs e)
        {
            dtFechaDeViaje.MinDate = ConfigurationHelper.FechaActual;
            txtOrigen.AutoCompleteCustomSource = CargarDatos();
            txtDestino.AutoCompleteCustomSource = CargarDatos();
        }

        private AutoCompleteStringCollection CargarDatos()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            Dictionary<string, List<object>> origen = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "descripcion" }), null);

            for (int i = 0; i < origen["descripcion"].Count; i++)
            {
                datos.Add(origen["descripcion"][i].ToString());
            }

            return datos;
        }

        private void BtnBuscarViajes_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                if (HayViajes())
                {
                    this.Visible = false;
                    if(new SeleccionarViaje(Convert.ToDateTime(dtFechaDeViaje.Value), getIdPuerto(txtOrigen.Text.ToString()), getIdPuerto(txtDestino.Text.ToString())).ShowDialog() == DialogResult.OK)
                    {
                        txtDestino.Text = string.Empty;
                        txtOrigen.Text = string.Empty;
                        dtFechaDeViaje.Value = ConfigurationHelper.FechaActual;

                    }
                    Visible = true;
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

        private List<Filtro> filtrosIgualDestino(string campo)
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("CAST(fecha_inicio AS DATE)", dtFechaDeViaje.Value.ToString("yyyy-MM-dd")));
            filtros.Add(FiltroFactory.Exacto("puertoOrigen", getIdPuerto(txtOrigen.Text.ToString())));
            filtros.Add(FiltroFactory.Exacto(campo, getIdPuerto(txtDestino.Text.ToString())));

            return filtros;
        }

        private bool HayViajes()
        {

            return conexion.ExisteRegistro(Tabla.ViajesEnFechaYOrigenDestino, new List<string>(new string[] { "viaje" }), filtrosIgualDestino("tramoPuertoDestino"));
        }

        private string getIdPuerto(string descripcion)
        {
            List<Filtro> filtrosPuerto = new List<Filtro>();
            filtrosPuerto.Add(FiltroFactory.Libre("descripcion", descripcion));

            Dictionary<string, List<object>> puerto = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtrosPuerto);

            return puerto["ID"].First().ToString();
        }

        // ---------------------------------------VALIDACIONES------------------------------------------
        private String ValidarCampos()
        {
            String resultado = "";

            resultado += this.ValidarCamposVacios();

            // PUERTO ORIGEN
            resultado += this.ValidarSoloLetras(txtOrigen.Text.ToString(), "origen");
            resultado += this.ValidarExistenciaPuerto(resultado, txtOrigen.Text.ToString(), "origen");

            // PUERTO DESTINO
            resultado += this.ValidarSoloLetras(txtDestino.Text.ToString(), "destino");
            resultado += this.ValidarExistenciaPuerto(resultado, txtDestino.Text.ToString(), "destino");

            return resultado;
        }

        private String ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtOrigen.Text) || string.IsNullOrEmpty(txtDestino.Text))
            {
                return "Se detecto un campo vacio. Revise. \n";
            }

            return "";
        }

        private String ValidarSoloLetras(String texto, String tipoDeCampo)
        {
            foreach (char letra in texto.Trim())
            {
                if (!(char.IsLetter(letra) || char.IsWhiteSpace(letra) || letra.Equals('-') || letra.Equals(',')))
                    return "En el campo " + tipoDeCampo + " solo se pueden ingresar letras. \n";
            }

            return "";
        }

        private String ValidarExistenciaPuerto(String resultado, String descripcionPuerto, String tipoPuerto)
        {
            if (resultado == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Libre("descripcion", descripcionPuerto));

                Dictionary<string, List<object>> puerto = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "descripcion" }), filtros);

                if (puerto["descripcion"].Count() == 1) 
                    return "";

                return "El puerto " + tipoPuerto + " no existe.\n";
            }

            return "";
        }
    }
}