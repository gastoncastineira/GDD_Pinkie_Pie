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

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoReserva : FormTemplate
    {

        private Conexion conexion = new Conexion();
        
        public PagoReserva():base()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.camposVacios())
            {
                MessageBox.Show("Se han encontrado campos vacios. Por favor completelos e intentelo nuevamente", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                List<Filtro> filtros2 = new List<Filtro>();
                filtros2.Add(FiltroFactory.Exacto("codigo", textBox1.Text));
                filtros2.Add(FiltroFactory.Exacto("pagado", "0"));
                List<string> colum = new List<string>();
                colum.Add("ID");
                colum.Add("cliente_id");
                colum.Add("fecha_de_reserva");
                colum.Add("cabina_id");
                colum.Add("precio");
                Dictionary<string, List<object>> resulta3 = conexion.ConsultaPlana(Tabla.Reserva, colum, filtros2);
                if (resulta3["precio"].Count == 0)
                {
                    MessageBox.Show("No se encontro reserva con ese código","Error ID Reserva",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var fkPago = 1;
                if (cmbMetodoDePago.Text != "EFECTIVO")
                {

                    List<Filtro> filtros = new List<Filtro>();
                    filtros.Add(FiltroFactory.Exacto("tipo", cmbMetodoDePago.Text));
                    filtros.Add(FiltroFactory.Exacto("numero_de_tarjeta", txtNumeroDeTarjerta.Text));

                    List<string> col = new List<string>();
                    col.Add("ID");

                    Dictionary<string, List<object>> resul = conexion.ConsultaPlana(Tabla.MedioDePago, col, filtros);

                    if (resul["ID"].Count > 0)
                    {
                        fkPago = int.Parse(resul["ID"][0].ToString());
                    }
                    else
                    {

                        Dictionary<string, object> campos = new Dictionary<string, object> { { "tipo", cmbMetodoDePago.Text }, { "numero_de_tarjeta", txtNumeroDeTarjerta.Text } };
                        fkPago = conexion.Insertar(Tabla.MedioDePago, campos);

                    }

                }

                DateTime fecha = Convert.ToDateTime(resulta3["fecha_de_reserva"][0]);
                TimeSpan dif = ConfigurationHelper.FechaActual.Subtract(fecha);
                if (dif.Days > 3)
                {
                    MessageBox.Show("Esa reserva se encuentra vencida", "Reserva vencida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Dictionary<string, object> valores = new Dictionary<string, object>();
                valores["cliente_id"] = resulta3["cliente_id"][0];
                valores["fecha_de_compra"] = resulta3["fecha_de_reserva"][0];
                valores["cabina_id"] = resulta3["cabina_id"][0];
                valores["medio_de_pago_id"] = fkPago;
                valores["precio"] = resulta3["precio"][0];
                if (MessageBox.Show("El precio total es de " + resulta3["precio"][0].ToString() + "\n¿Desea continuar?", "confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (conexion.Insertar(Tabla.Pasaje, valores) != -1)
                    {

                        conexion.PagarReserva(int.Parse(textBox1.Text), Tabla.Reserva);

                        MessageBox.Show("Se pago el pasaje exitosamente", "Pago exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNumeroDeTarjerta.Text = string.Empty;
                        cmbCantidadDeCuotas.Text = string.Empty;
                        cmbMetodoDePago.Text = string.Empty;
                        textBox1.Text = string.Empty;
                    }
                    else
                    {

                        MessageBox.Show("Hubo un error, intente de nuevo más tarde", "Error rancio", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                    MessageBox.Show("Se cancelo la operacion", "Operacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }

        }

        private void txtNumeroDeTarjerta_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }

        }

        private bool camposVacios(){
            if (cmbCantidadDeCuotas.Text.ToLower() == "credito")
                return this.stringVacio(textBox1.Text) || this.stringVacio(cmbMetodoDePago.Text) || this.stringVacio(txtNumeroDeTarjerta.Text) || this.stringVacio(cmbCantidadDeCuotas.Text);
            else if (cmbCantidadDeCuotas.Text.ToLower() == "debito")
                return this.stringVacio(textBox1.Text) || this.stringVacio(cmbMetodoDePago.Text) || this.stringVacio(txtNumeroDeTarjerta.Text);
            else
                return this.stringVacio(textBox1.Text) || this.stringVacio(cmbMetodoDePago.Text);
        }


        private bool stringVacio(string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }

        private void cmbMetodoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbMetodoDePago.Text == "EFECTIVO")
            {
                txtNumeroDeTarjerta.Visible = false;
                cmbCantidadDeCuotas.Visible = false;
                txtNumeroDeTarjerta.Text = "asd";
                cmbCantidadDeCuotas.Text = "0";
                lblNumeroDeTarjeta.Visible = false;
                lblCantidadDeCuotas.Visible = false;
            }
            else
            {
                txtNumeroDeTarjerta.Visible = true;
                cmbCantidadDeCuotas.Visible = true;
                txtNumeroDeTarjerta.Text = "";
                cmbCantidadDeCuotas.Text = "";
                lblNumeroDeTarjeta.Visible = true;
                lblCantidadDeCuotas.Visible = true;
            }

            if (cmbMetodoDePago.Text == "DEBITO")
            {

                cmbCantidadDeCuotas.Visible = false;
                cmbCantidadDeCuotas.Text = "0";
                lblCantidadDeCuotas.Visible = false;
            }


        }

        private void PagoReserva_Load(object sender, EventArgs e)
        {
            txtNumeroDeTarjerta.Visible = false;
            cmbCantidadDeCuotas.Visible = false;
            txtNumeroDeTarjerta.Text = "asd";
            cmbCantidadDeCuotas.Text = "0";
            lblNumeroDeTarjeta.Visible = false;
            lblCantidadDeCuotas.Visible = false;
        }

    }
}
