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
        private int CantidadDePasajes;
        private double PrecioTotal;
        private Viaje ViajeElegido;
        public Cliente ClienteComprador;
        private Conexion conexion = new Conexion();


        public MedioDePago(int cantPasajes, Viaje viaje, string idPuertoOrigen, string idPuertoDestino, Cliente cliente, double precioTotal) : base()
        {
            CantidadDePasajes = cantPasajes;
            ViajeElegido = viaje;
            IdPuertoOrigen = idPuertoOrigen;
            IdPuertoDestino = idPuertoDestino;
            ClienteComprador = cliente;
            PrecioTotal = precioTotal;

            InitializeComponent();
        }

        private void MedioDePago_Load(object sender, EventArgs e)
        {
            lblMetodoDePago.Visible = false;
            cmbMetodoDePago.Visible = false;
            lblCantidadDeCuotas.Visible = false;
            cmbCantidadDeCuotas.Visible = false;
            lblNumeroDeTarjeta.Visible = false;
            txtNumeroDeTarjerta.Visible = false;

            lblPrecioTotal.Text = "La cantidad a pagar es " + PrecioTotal.ToString();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;

                if (new Confirmacion(CantidadDePasajes, ViajeElegido, IdPuertoOrigen, IdPuertoDestino, ClienteComprador, PrecioTotal, GetMetodoDePago(), cmbTipoOperacion.Items[cmbTipoOperacion.SelectedIndex].ToString()).ShowDialog() == DialogResult.OK)
                    DialogResult = DialogResult.OK;
                else
                    Visible = true;
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private MetodoDePago GetMetodoDePago()
        {
            if (cmbTipoOperacion.Items[cmbTipoOperacion.SelectedIndex].ToString() == "COMPRA")
            {
                MetodoDePago medioDePago = new MetodoDePago();

                medioDePago.Tipo = cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString();

                if (cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString() != "EFECTIVO")
                    medioDePago.NumeroTarjeta = Convert.ToInt32(txtNumeroDeTarjerta.Text);

                return medioDePago;
            }

            return null;
        }

        private void CmbMetodoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString() == "CREDITO"
                || cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString() == "DEBITO")
            {
                lblNumeroDeTarjeta.Visible = true;
                txtNumeroDeTarjerta.Visible = true;

                if (cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString() == "CREDITO")
                {
                    lblCantidadDeCuotas.Visible = true;
                    cmbCantidadDeCuotas.Visible = true;
                }
                else
                {
                    lblCantidadDeCuotas.Visible = false;
                    cmbCantidadDeCuotas.Visible = false;
                }
            }
            else
            {
                lblCantidadDeCuotas.Visible = false;
                cmbCantidadDeCuotas.Visible = false;
                lblNumeroDeTarjeta.Visible = false;
                txtNumeroDeTarjerta.Visible = false;
            }
        }

        private void CmbTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoOperacion.Items[cmbTipoOperacion.SelectedIndex].ToString() == "COMPRA")
            {
                lblMetodoDePago.Visible = true;
                cmbMetodoDePago.Visible = true;
                lblCantidadDeCuotas.Visible = false;
                cmbCantidadDeCuotas.Visible = false;
                lblNumeroDeTarjeta.Visible = false;
                txtNumeroDeTarjerta.Visible = false;
            }
            else
            {
                lblMetodoDePago.Visible = false;
                cmbMetodoDePago.Visible = false;
                lblCantidadDeCuotas.Visible = false;
                cmbCantidadDeCuotas.Visible = false;
                lblNumeroDeTarjeta.Visible = false;
                txtNumeroDeTarjerta.Visible = false;
            }
        }


        // ---------------------------------------VALIDACIONES------------------------------------------
        private string ValidarCampos()
        {
            string resultado = "";

            // Tipo de operacion
            resultado += ValidarSeSeleccionoTipoOperacion();

            // Metodo de pago
            resultado += ValidarSeSeleccionoMetodoDePago(resultado);

            // Numero de tarjeta
            resultado += ValidarCampoVacio(resultado);
            resultado += ValidarSoloNumeros(resultado);

            // Cantidad de cuotas
            resultado += ValidarSeSeleccionoCuotas(resultado);

            return resultado;
        }

        private string ValidarSeSeleccionoTipoOperacion()
        {
            if (cmbTipoOperacion.SelectedIndex != -1)
                return "";

            return "Debe ingresar un tipo de operación.\n";
        }

        private string ValidarSeSeleccionoMetodoDePago(string resultado)
        {
            if (resultado == "")
            {
                if (cmbTipoOperacion.Items[cmbTipoOperacion.SelectedIndex].ToString() == "COMPRA")
                {
                    if (cmbMetodoDePago.SelectedIndex == -1)
                        return "Debe ingresar un método de pago.\n";
                }
            }

            return "";
        }

        private string ValidarCampoVacio(string resultado)
        {
            if(resultado == "")
            {
                if(cmbTipoOperacion.Items[cmbTipoOperacion.SelectedIndex].ToString() == "COMPRA")
                {
                    if (cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString() != "EFECTIVO")
                    {
                        if (string.IsNullOrEmpty(txtNumeroDeTarjerta.Text))
                            return "El campo del numero de número de tarjeta no debe estar vacio. Revise.\n";
                    }
                }    
            } 

            return "";
        }

        private string ValidarSoloNumeros(string resultado)
        {
            if (resultado == "")
            {
                if (cmbTipoOperacion.Items[cmbTipoOperacion.SelectedIndex].ToString() == "COMPRA")
                {
                    if (cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString() != "EFECTIVO")
                    {
                        foreach (char letra in txtNumeroDeTarjerta.Text.ToString())
                        {
                            if (!char.IsNumber(letra))
                                return "En el campo numero de tarjeta solo se pueden ingresar numeros. \n";
                        }
                    }
                }      
            }

            return "";
        }

        private string ValidarSeSeleccionoCuotas(string resultado)
        {
            if (resultado == "")
            {
                if (cmbTipoOperacion.Items[cmbTipoOperacion.SelectedIndex].ToString() == "COMPRA")
                {
                    if (cmbMetodoDePago.Items[cmbMetodoDePago.SelectedIndex].ToString() == "CREDITO")
                    {
                        if (cmbCantidadDeCuotas.SelectedIndex == -1)
                            return "Se debe seleccionar la cantidad de cuotas.\n";
                    }
                }
            }

            return "";
        }
    }
}
