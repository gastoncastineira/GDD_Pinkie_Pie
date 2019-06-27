using Conexiones;
using FrbaCrucero.CompraPasaje;
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
    public partial class SeleccionarViaje : Form
    {
        private Conexion conexion = new Conexion();
        private DataTable Datos;
        private int NumPag = 0;
        private DateTime FechaInicioViaje;
        private string IdPuertoOrigen, IdPuertoDestino;
        private double PrecioTotal;

        public SeleccionarViaje(DateTime fechaInicioViaje, string idPuertoOrigen, string idPuertoDestino) : base()
        {
            InitializeComponent();
            FechaInicioViaje = fechaInicioViaje;
            IdPuertoOrigen = idPuertoOrigen;
            IdPuertoDestino = idPuertoDestino;
        }

        private void SeleccionarViaje_Load(object sender, EventArgs e)
        {
            List<Filtro> filtrosPuerto = new List<Filtro>();
            filtrosPuerto.Add(FiltroFactory.Exacto("ID", IdPuertoDestino));

            Dictionary<string, List<object>> puerto = conexion.ConsultaPlana(Tabla.Puerto, new List<string>(new string[] { "descripcion" }), filtrosPuerto);

            lblMostrar.Text += puerto["descripcion"].First().ToString();

            LlenarDGVViajes(FiltroFactory.Exacto("T_PUERTO_DESTINO", IdPuertoDestino));
            LlenarDGVTramos(0);
            LlenarDGVCabinasDisponibles(0);
        }

        private void LlenarDGVViajes(Filtro destino)
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("CAST(FECHA_INICIO AS DATE)", FechaInicioViaje.ToString("yyyy-MM-dd")));
            filtros.Add(FiltroFactory.Exacto("ID_PUERTO_ORIGEN_RECORRIDO", IdPuertoOrigen));
            filtros.Add(destino);

            Datos = conexion.ConseguirTabla(Tabla.ViajesDisponiblesGridView, filtros);
            PasarPagina();
        }

        private void LlenarDGVTramos(int posicion)
        {
            List<Filtro> listFiltro = new List<Filtro>();
            listFiltro.Add(FiltroFactory.Exacto("RECORRIDO_ID", dtViajes.Rows[posicion].Cells[7].Value.ToString()));
            conexion.LlenarDataGridView(Tabla.TramosParaGridView, ref dtTramos, listFiltro);

            dtTramos.Columns[0].Visible = false;
            dtTramos.Columns[1].Visible = false;
            dtTramos.ClearSelection();
        }

        private void LlenarDGVCabinasDisponibles(int posicion)
        {
            List<Filtro> listFiltro = new List<Filtro>();
            listFiltro.Add(FiltroFactory.Exacto("viaje_id", dtViajes.Rows[posicion].Cells[8].Value.ToString()));
            conexion.LlenarDataGridView(Tabla.CabinasDisponiblesGridView, ref dtCabinasDisponibles, listFiltro);

            dtCabinasDisponibles.Columns[2].Visible = false;
            dtCabinasDisponibles.Columns[3].Visible = false;
        }

        private void PasarPagina()
        {
            int cantPag = NumPag * 10;
            DataTable data = Datos.Clone();

            for (int i = cantPag; i < cantPag + 10; i++)
            {
                try
                {
                    data.ImportRow(Datos.Rows[i]);
                }

                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            dtViajes.DataSource = data;

            dtViajes.Columns[5].Visible = false;
            dtViajes.Columns[6].Visible = false;
            dtViajes.Columns[7].Visible = false;
            dtViajes.Columns[8].Visible = false;
            dtViajes.Columns[11].Visible = false;
            dtViajes.Columns[12].Visible = false;
        }

        private void BtnPrimerPagina_Click(object sender, EventArgs e)
        {
            DataTable data = Datos.Clone();

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    data.ImportRow(Datos.Rows[i]);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            dtViajes.DataSource = data;
        }

        private void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (NumPag > 0)
            {
                NumPag--;
                PasarPagina();
            }
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            int cantMaxPags = Datos.Rows.Count / 10 + 1;

            if (NumPag < cantMaxPags && cantMaxPags != 1)
            {
                NumPag++;
                PasarPagina();
            }
        }

        private void BtnUltimaPagina_Click(object sender, EventArgs e)
        {
            NumPag = Datos.Rows.Count / 10;
            int cantPag = NumPag * 10;
            DataTable data = Datos.Clone();

            for (int i = cantPag; i < cantPag + 10; i++)
            {
                try
                {
                    data.ImportRow(Datos.Rows[i]);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            dtViajes.DataSource = data;
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;

                Viaje viaje = new Viaje();
                viaje.Id = Convert.ToInt32(dtViajes.CurrentRow.Cells[8].Value);
                viaje.FechaInicio = FechaInicioViaje;
                viaje.Fecha_Fin_Estimada = Convert.ToDateTime(dtViajes.CurrentRow.Cells[1].Value);
                viaje.Recorrido_id = Convert.ToInt16(dtViajes.CurrentRow.Cells[7].Value);

                List<Cabina> cabinas = new List<Cabina>();

                Cabina cabina = new Cabina();
                cabina.Crucero_id = Convert.ToInt16(dtViajes.CurrentRow.Cells[11].Value);
                cabina.Tipo_id = Convert.ToInt16(dtCabinasDisponibles.CurrentRow.Cells[3].Value);

                cabinas.Add(cabina);
                viaje.Cabinas = cabinas;

                if(new DatosPersonales(Convert.ToInt16(txtCantidadPasajes.Text), viaje, IdPuertoOrigen, IdPuertoDestino, PrecioTotal).ShowDialog() == DialogResult.OK)
                    DialogResult = DialogResult.OK;
                else
                    Visible = true;
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DtViajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                LlenarDGVTramos(e.RowIndex);
                LlenarDGVCabinasDisponibles(e.RowIndex);
                CambiarPrecioTotal();
            }
        }

        private void TxtCantidadPasajes_TextChanged(object sender, EventArgs e)
        {
            CambiarPrecioTotal();
        }

        private void DtCabinasDisponibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                CambiarPrecioTotal();
        }

        private void CambiarPrecioTotal()
        {
            if (ValidarCampos() == "")
            {
                PrecioTotal = Convert.ToDouble(txtCantidadPasajes.Text)
                    * Convert.ToDouble(dtCabinasDisponibles.CurrentRow.Cells["PORCENTAJE_COSTO"].Value)
                    * Convert.ToDouble(dtViajes.CurrentRow.Cells[4].Value);
                lblPrecioTotal.Text = "Precio total: " + PrecioTotal.ToString();
            }
        }

        // ---------------------------------------VALIDACIONES------------------------------------------
        private String ValidarCampos()
        {
            string resultado = "";

            resultado += this.ValidarCamposVacios();
            resultado += this.ValidarSoloNumeros(txtCantidadPasajes.Text.ToString());

            return resultado;
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

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.Items[cmbFiltro.SelectedIndex].ToString() == "SI")
                LlenarDGVViajes(FiltroFactory.Exacto("RECORRIDO_ID_DESTINO", IdPuertoDestino));
            else
                LlenarDGVViajes(FiltroFactory.Exacto("T_PUERTO_DESTINO", IdPuertoDestino));
        }

        private String ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtCantidadPasajes.Text))
            {
                return "Debe indicar la cantidad de pasajes. \n";
            }

            return "";
        }
    }
}