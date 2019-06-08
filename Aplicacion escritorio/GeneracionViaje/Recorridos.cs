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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class Recorridos : Form 
    {
        private Conexion conexion = new Conexion();
        public Recorridos()
        {
            InitializeComponent();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridRecorridos.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Recorridos_Load(object sender, EventArgs e)
        {
            ReLoad(null);
        }

        private void ReLoad(List<Filtro> filtros)
        {
            conexion.LlenarDataGridView(Tabla.RecorridosParaGridView, ref dataGridRecorridos, filtros);

            dataGridRecorridos.Columns[3].Visible = false;
            dataGridRecorridos.ClearSelection();
        }

        private void BtlBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Filtro> filtros = new List<Filtro>();

                if (string.IsNullOrEmpty(txtBuscar.Text.Trim()) == false)
                    filtros.Add(FiltroFactory.Libre("RECORRIDO", txtBuscar.Text.Trim()));

                ReLoad(filtros);

            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridRecorridos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                List<Filtro> listFiltro = new List<Filtro>();
                listFiltro.Add(FiltroFactory.Exacto("RECORRIDO_ID", dataGridRecorridos.Rows[e.RowIndex].Cells[0].Value.ToString()));
                conexion.LlenarDataGridView(Tabla.TramosParaGridView, ref dataGridViewTramos, listFiltro);
                dataGridViewTramos.ClearSelection();
            }
        }
    }

}
