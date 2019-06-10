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
using FrbaCrucero.Acceso;

namespace FrbaCrucero.AbmCrucero
{
    public partial class ListaDeCruceros : Form
    {
        private Conexion conexion = new Conexion();
        public ListaDeCruceros()
        {
            InitializeComponent();

        }

        private void ListaDeRecorridos_Load(object sender, EventArgs e)
        {
            this.reLoad();
        }

        public void reLoad()
        {
            conexion.LlenarDataGridView(Tabla.Crucero, ref dataGridViewCruceros, null);
            dataGridViewCabinas.DataSource = null;
            dataGridViewCabinas.Rows.Clear();
            dataGridViewCabinas.Refresh();
        }

        private void DataGridViewRecorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string PK = dataGridViewCruceros.Rows[e.RowIndex].Cells[3].Value.ToString();

            switch (e.ColumnIndex)
            {
                case 0:
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {   //Dar de baja
                    }
                    break;
                case 1:
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {   //Modificar
                        new ModificarCrucero(PK,
                            dataGridViewCruceros.Rows[e.RowIndex].Cells[4].Value.ToString(),
                            dataGridViewCruceros.Rows[e.RowIndex].Cells[5].Value.ToString(),
                            dataGridViewCruceros.Rows[e.RowIndex].Cells[6].Value.ToString()
                            ,this).Show();
                    }
                    break;
                case 2:
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {   //Ver datos
                        List<Filtro> listFiltro = new List<Filtro>();
                        listFiltro.Add(FiltroFactory.Exacto("Crucero", PK));
                        conexion.LlenarDataGridView(Tabla.CabinasDeCrucero, ref dataGridViewCabinas, listFiltro);
                    }
                    break;
            }
        }

        private void LabelNombreGrid_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCrear_Click(object sender, EventArgs e)
        {

        }

        private void ButtonOut_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }
    }
}
