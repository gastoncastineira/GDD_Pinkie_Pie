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
using FrbaCrucero.CompraReservaPasaje;
using FrbaCrucero.model;

namespace FrbaCrucero.CompraPasaje
{
    public partial class ComprarReservarViaje : Form
    {
        private String IdOrigen;
        private String IdDestino;
        private List<Viaje> Viajes = new List<Viaje>();
        private Conexion conexion = new Conexion();

        public ComprarReservarViaje()
        {
            InitializeComponent();
        }

        private void ComprarReservarViaje_Load(object sender, EventArgs e)
        {
            AutoCompletarOrigen();
            AutoCompletarDestino();
        }

        public void AutoCompletarOrigen()
        {
            if (txtOrigen != null)
            {
                List<Filtro> filtrosOrigen = new List<Filtro>();
                filtrosOrigen.Add(FiltroFactory.Libre("descripcion", txtOrigen.ToString()));

                Dictionary<string, List<object>> dicOrigen = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtrosOrigen);

                if (dicOrigen["ID"].Count == 1)
                    IdOrigen = dicOrigen["ID"].First().ToString();
            }

            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Distinto("ID", IdOrigen));
            filtros.Add(FiltroFactory.Libre("descripcion", txtDestino.ToString()));

            Dictionary<string, List<object>> origen = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtros);
            //  TODO seguir, ver https://www.youtube.com/watch?v=PTod0kV91Xs
        }

        public void AutoCompletarDestino()
        {
            if (txtDestino != null)
            {
                List<Filtro> filtrosDestino = new List<Filtro>();
                filtrosDestino.Add(FiltroFactory.Libre("descripcion", txtOrigen.ToString()));

                Dictionary<string, List<object>> dicDestino = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtrosDestino);

                if (dicDestino["ID"].Count == 1)
                    IdDestino = dicDestino["ID"].First().ToString();
            }

            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Distinto("ID", IdDestino));
            filtros.Add(FiltroFactory.Libre("descripcion", txtDestino.ToString()));

            Dictionary<string, List<object>> destino = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtros);
            //  TODO seguir, ver https://www.youtube.com/watch?v=PTod0kV91Xs
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
            /*
             SELECT viaje_id
	FROM Viaje v
	JOIN Recorrido r
		ON r.puertoOrigen_id = idOrigen
	JOIN Tramo_Recorrido tr
		ON tr.recorrido_id = r.recorrido_id
	JOIN Tramo t
		ON t.tramo_id = tr.tramo_id
	WHERE v.fechaInicio = fechaInicio AND 
	(t.puertoDestino_id = idDestino || r.puertoDestino_id = idDestino)
             */
        }


        // VALIDACIONES
        private String ValidarCampos()
        {
            String resultado = "";

            resultado += this.ValidarCamposVacios();

            //  A PASAJES A COMPRAR
            resultado += this.ValidarSoloNumeros(txtCantidadPasajes.Text);

            // PUERTO ORIGEN
            resultado += this.ValidarExistenciaPuerto(resultado, IdOrigen, "origen");

            // PUERTO DESTINO
            resultado += this.ValidarExistenciaPuerto(resultado, IdDestino, "destino");

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

        private String ValidarSoloNumeros(String texto)
        {
            foreach (char letra in texto.Trim())
            {
                if (!char.IsNumber(letra))
                    return "En cantidad de pasajes solo se pueden ingresar numeros. \n";
            }

            return "";
        }

        private String ValidarExistenciaPuerto(String resultado, String idPuerto, String tipoPuerto)
        {
            if (resultado == "")
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("ID", idPuerto));

                if (conexion.ExisteRegistro(Tabla.Puerto, new List<string>(new string[] { "ID" }), filtros))
                    return "";

                return "El puerto " + tipoPuerto + " no existe.\n";
            }

            return "";
        }
    }
}