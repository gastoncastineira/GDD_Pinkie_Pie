using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexiones;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoEstadistico : FormTemplate
    {
        private Conexion conn;
        private DateTime inicio;
        private DateTime fin;

        public ListadoEstadistico() : base()
        {
            InitializeComponent();
            conn = new Conexion();
            for (int i = 2010; i <= ConfigurationHelper.FechaActual.Year; cbbAño.Items.Add((i++).ToString()));
        }

        private void CalcularFechas()
        {
            if (cbbSemestre.Text == "1")
            {
                inicio = DateTime.Parse("1/1/" + cbbAño.Text);
                fin = Convert.ToDateTime("30/6/"+cbbAño.Text);
            }
            else
            {
                inicio = Convert.ToDateTime("1/7/"+cbbAño.Text);
                fin = Convert.ToDateTime("31/12/"+cbbAño.Text);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAño.Text) || string.IsNullOrEmpty(cbbSemestre.Text))
            {
                MessageBox.Show("DEBE ingresar un año y un semestre");
                return;
            }
            CalcularFechas();
            dgvResultados.DataSource = conn.TraerLitadoEstadistico(Tabla.Top5PuntosClientes, inicio, fin);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAño.Text) || string.IsNullOrEmpty(cbbSemestre.Text))
            {
                MessageBox.Show("DEBE ingresar un año y un semestre");
                return;
            }
            CalcularFechas();
            dgvResultados.DataSource = conn.TraerLitadoEstadistico(Tabla.Top5ViajesCabinasVacias, inicio, fin);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAño.Text) || string.IsNullOrEmpty(cbbSemestre.Text))
            {
                MessageBox.Show("DEBE ingresar un año y un semestre");
                return;
            }
            CalcularFechas();
            dgvResultados.DataSource = conn.TraerLitadoEstadistico(Tabla.Top5CrucerosFueraServicio, inicio, fin);
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbAño.Text) || string.IsNullOrEmpty(cbbSemestre.Text))
            {
                MessageBox.Show("DEBE ingresar un año y un semestre");
                return;
            }
            CalcularFechas();
            dgvResultados.DataSource = conn.TraerLitadoEstadistico(Tabla.Top5RecorridosPasajes, inicio, fin);
        }
    }
}
