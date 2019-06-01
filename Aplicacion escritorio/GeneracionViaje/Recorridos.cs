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
    public partial class Recorridos : Form // TODO ver si hago Consulta y que las demas hereden o lo dejo asi
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
                MessageBox.Show("Tiene que seleccionar un recorrido. \n", "Error");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Recorridos_Load(object sender, EventArgs e)
        {
            LlenarDataGV(null);
        }

        private void BtlBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text.Trim()) == false) 
            {
                try
                {
                    List<Filtro> filtros = new List<Filtro>();

                    if (string.IsNullOrEmpty(txtBuscar.Text.Trim()) == false)
                        filtros.Add(FiltroFactory.Libre("ID", txtBuscar.Text.Trim()));

                    LlenarDataGV(filtros);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void LlenarDataGV(List<Filtro> filtros)
        {
            DataTable data = conexion.ConseguirTabla(Tabla.Recorrido, filtros);

            data.Columns.Remove("codigo");
            data.Columns.RemoveAt(1);
            data.Columns.Add("origenNombre", typeof(String));
            data.Columns.Add("destinoNombre", typeof(String));

            // le agrego al dataTable la descripcion de origen y la descripcion de destino
            for (int i = 0; i < data.Rows.Count; i++)
            {
                List<string> campos = new List<string>();
                campos.Add("descripcion");

                // obtengo el nombre del puerto origen
                List<Filtro> filtroOrigen = new List<Filtro>();
                filtroOrigen.Add(FiltroFactory.Exacto("ID", Convert.ToString(data.Rows[i]["puerto_origen_id"])));

                Dictionary<string, List<object>> origen = conexion.ConsultaPlana(Tabla.Puerto, campos, filtroOrigen);

                // obtengo el nombre del puerto destino
                List<Filtro> filtroDestino = new List<Filtro>();
                filtroDestino.Add(FiltroFactory.Exacto("ID", Convert.ToString(data.Rows[i]["puerto_destino_id"])));

                Dictionary<string, List<object>> destino = conexion.ConsultaPlana(Tabla.Puerto, campos, filtroDestino);


                // los agrego al dataTable
                DataRow dr = data.Rows[i];
                dr[3] = origen["descripcion"].First();
                dr[4] = destino["descripcion"].First();
            }
            

            dataGridRecorridos.DataSource = data;
        }

        private void Recorridos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            new GenerarViaje().Show();
        }
    }

}
