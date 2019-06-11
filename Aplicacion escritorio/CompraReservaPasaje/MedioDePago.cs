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
    public partial class MedioDePago : Form
    {
        public string IdPuertoOrigen, IdPuertoDestino, RecorridoId;
        private int CantidadDePasajes, PrecioTotal;
        private Viaje ViajeElegido;
        public Cliente ClienteComprador;
        private Conexion conexion = new Conexion();


        public MedioDePago(int cantPasajes, Viaje viaje, string idPuertoOrigen, string idPuertoDestino, Cliente cliente, int precioTotal)
        {
            CantidadDePasajes = cantPasajes;
            ViajeElegido = viaje;
            IdPuertoOrigen = idPuertoOrigen;
            IdPuertoDestino = idPuertoDestino;
            ClienteComprador = cliente;
            PrecioTotal = precioTotal;

            InitializeComponent();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;

                new Confirmacion(CantidadDePasajes, ViajeElegido, IdPuertoOrigen, IdPuertoDestino, ClienteComprador, PrecioTotal, GetMetodoDePago(), cmbMetodoDePago.SelectedValue.ToString()).Show();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new DatosPersonales(CantidadDePasajes, ViajeElegido, IdPuertoOrigen, IdPuertoDestino, PrecioTotal).Show();
        }

        private MetodoDePago GetMetodoDePago()
        {
            MetodoDePago medioDePago = new MetodoDePago();

            medioDePago.Tipo = cmbMetodoDePago.SelectedValue.ToString();
            medioDePago.NumeroTarjeta = Convert.ToInt32(txtNumeroDeTarjerta.Text.ToString());

            return medioDePago;
        }

        private void CmbMetodoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoDePago.SelectedValue.ToString() == "CREDITO" || cmbMetodoDePago.SelectedValue.ToString() == "DEBITO")
            {
                lblNumeroDeTarjeta.Visible = true;
                txtNumeroDeTarjerta.Visible = true;

                if (cmbMetodoDePago.SelectedValue.ToString() == "CREDITO")
                {
                    lblCantidadDeCuotas.Visible = true;
                    cmbCantidadDeCuotas.Visible = true;
                }
            }

        }

        private void MedioDePago_Load(object sender, EventArgs e)
        {
            lblCantidadDeCuotas.Visible = false;
            cmbCantidadDeCuotas.Visible = false;
            lblNumeroDeTarjeta.Visible = false;
            txtNumeroDeTarjerta.Visible = false;

            Dictionary<string, List<object>> medioDePago = conexion.ConsultaPlana(Tabla.MedioDePago, new List<string>(new string[] { "tipo" }), null);

            for (int i = 0; i < Convert.ToInt16(medioDePago["tipo"].Count); i++)
            {
                cmbMetodoDePago.Items.Add(medioDePago["tipo"][i].ToString());
            }

            lblPrecioTotal.Text = "La cantidad a pagar es " + PrecioTotal.ToString();
        }

        // ---------------------------------------VALIDACIONES------------------------------------------
        private string ValidarCampos()
        {
            string resultado = "";

            // Metodo de pago
            resultado += ValidarSeSeleccionoMetodoDePago();

            // Numero de tarjeta
            resultado += ValidarCampoVacio(resultado);

            return resultado;
        }

        private string ValidarSeSeleccionoMetodoDePago()
        {
            if (cmbMetodoDePago.SelectedItem.ToString() != "")
                return "";

            return "Debe ingresar un método de pago.\n";
        }

        private string ValidarCampoVacio(string resultado)
        {
            if (cmbMetodoDePago.SelectedText != "EFECTIVO" && resultado == "")
            {
                if (string.IsNullOrEmpty(txtNumeroDeTarjerta.Text))
                    return "El campo del numero de metodo de pago no debe estar vacio. Revise.\n";
            }

            return "";
        }
    }
}
