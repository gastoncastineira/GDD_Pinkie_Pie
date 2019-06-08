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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class SeleccionarViaje : Form
    {
        private Conexion conexion = new Conexion();
        private DataTable Datos;
        private int NumPag = 0;
        private string FechaInicioViaje, IdPuertoOrigen, IdPuertoDestino;
        private int PrecioTotal;


        public SeleccionarViaje(string fechaInicioViaje, string idPuertoOrigen, string idPuertoDestino)
        {
            InitializeComponent();
            FechaInicioViaje = fechaInicioViaje;
            IdPuertoOrigen = idPuertoOrigen;
            IdPuertoDestino = idPuertoDestino;
        }

        private void SeleccionarViaje_Load(object sender, EventArgs e)
        {
            LlenarDGVViajes();
            LlenarDGVTramos(0);
            LlenarDGVCabinasDisponibles(0);
        }

        private void LlenarDGVViajes()
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("CAST(FECHA_INICIO AS DATE)", FechaInicioViaje));
            filtros.Add(FiltroFactory.Exacto("ID_PUERTO_ORIGEN_RECORRIDO", IdPuertoOrigen));
            filtros.Add(FiltroFactory.Exacto("T_PUERTO_DESTINO", IdPuertoDestino));

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
            this.Visible = false;
            new ComprarReservarViaje().Show();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            String mensaje = ValidarCampos();
            if (mensaje == "")
            {
                this.Visible = false;
                new DatosPersonales(txtCantidadPasajes.Text.ToString(), FechaInicioViaje, IdPuertoOrigen, IdPuertoDestino).Show();
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
                PrecioTotal = Convert.ToInt16(txtCantidadPasajes.Text)
                    * Convert.ToInt16(dtCabinasDisponibles.CurrentRow.Cells[1].Value)
                    * Convert.ToInt16(dtViajes.CurrentRow.Cells[4].Value);
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