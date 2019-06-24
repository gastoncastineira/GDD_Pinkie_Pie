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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class ListaDeRecorridos : FormTemplate
    {
        private Conexion conexion = new Conexion();
        public ListaDeRecorridos():base()
        {
            InitializeComponent();
        }

        private void ListaDeRecorridos_Load(object sender, EventArgs e)
        {
            this.reLoad();
        }

        public void reLoad()
        {
            conexion.LlenarDataGridView(Tabla.RecorridosParaGridView, ref dataGridViewRecorridos, null);
            dataGridViewTramos.DataSource = null;
            dataGridViewTramos.Rows.Clear();
            dataGridViewTramos.Refresh();
        }

        private void DataGridViewRecorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                string PK = dataGridViewRecorridos.Rows[e.RowIndex].Cells["RECORRIDO"].Value.ToString();

                switch (e.ColumnIndex)
                {
                    case 0:
                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                        {   //Dar de baja
                            conexion.deshabilitar(Tabla.Recorrido, int.Parse(PK));
                            this.reLoad();
                        }
                        break;
                    case 1:
                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                        {   //Dar de alta
                            conexion.habilitar(Tabla.Recorrido, int.Parse(PK));
                            this.reLoad();
                        }
                        break;
                    case 2:
                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                        {   //Modificar
                            ModificarRecorrido mod = new ModificarRecorrido(int.Parse(PK), dataGridViewRecorridos.Rows[e.RowIndex].Cells["PUERTO_DESTINO"].Value.ToString());
                            mod.ShowDialog();
                            reLoad();
                        }
                        break;
                    case 3:
                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                        {   //Ver datos
                            List<Filtro> listFiltro = new List<Filtro>();
                            listFiltro.Add(FiltroFactory.Exacto("RECORRIDO_ID", PK));
                            conexion.LlenarDataGridView(Tabla.TramosParaGridView, ref dataGridViewTramos, listFiltro);
                        }
                        break;
                }
            }
        }
        private void ButtonCrear_Click(object sender, EventArgs e)
        {
            CrearRecorrido create = new CrearRecorrido();
            create.ShowDialog();
            reLoad();
        }
    }
}
