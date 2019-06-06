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
        // para ponerle etiquetas a las columnas del dgv ver video 45
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
            conexion.LlenarDataGridView(Tabla.Recorrido, ref dataGridRecorridos, null);
            //  conexion.LlenarDataGridView(Tabla.TramosParaGridView, ref dataGridViewTramos, null );
        }

        private void BtlBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Filtro> filtros = new List<Filtro>();

                if (string.IsNullOrEmpty(txtBuscar.Text.Trim()) == false)
                    filtros.Add(FiltroFactory.Libre("ID", txtBuscar.Text.Trim()));

                conexion.LlenarDataGridView(Tabla.Recorrido, ref dataGridRecorridos, filtros);
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
    }

}
