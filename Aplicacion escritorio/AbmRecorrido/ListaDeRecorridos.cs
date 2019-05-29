﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexiones;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class ListaDeRecorridos : Form
    {
        private Conexion conexion = new Conexion();
        public ListaDeRecorridos()
        {
            InitializeComponent();

        }

        private void ListaDeRecorridos_Load(object sender, EventArgs e)
        {
            this.reLoad();
        }

        public void reLoad()
        {
            conexion.LlenarDataGridViewRecorridos(ref dataGridViewRecorridos);
            dataGridViewTramos.DataSource = null;
            dataGridViewTramos.Rows.Clear();
            dataGridViewTramos.Refresh();
        }

        private void DataGridViewRecorridos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string PK = dataGridViewRecorridos.Rows[e.RowIndex].Cells[4].Value.ToString() ;

            switch(e.RowIndex)
            {
                case 0:
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {   //Dar de baja
                        Dictionary<string, object> valor = new Dictionary<string, object>();
                        valor.Add("habilitado",1);
                        conexion.Modificar(int.Parse(PK),Tabla.Recorrido, valor);
                    }
                    break;
                case 1:
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {   //Modificar
                        ModificarRecorrido mod = new ModificarRecorrido(int.Parse(PK),this);
                        mod.Show();
                    }
                    break;
                case 2:
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {   //Ver datos
                        conexion.LlenarDataGridViewTramos( ref dataGridViewTramos, PK );
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
    }
}
