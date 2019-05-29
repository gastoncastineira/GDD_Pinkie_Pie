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
    public partial class Cruceros : Form //TODO Poner un Consultasen gral y que Cruceros y Recorridos hereden de ellos
    {
        private Conexion conexion = new Conexion();

        public Cruceros()
        {
            InitializeComponent();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {

            if (dataGridCruceros.Rows.Count == 0)
            {
                MessageBox.Show("Tiene que seleccionar un crucero. \n", "Error");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void Cruceros_Load(object sender, EventArgs e)
        {
            List<Filtro> filtros = new List<Filtro>();
            filtros.Add(FiltroFactory.Exacto("bajaPorFueraDeServicio", "false"));
            filtros.Add(FiltroFactory.Exacto("bajaPorVidaUtil", "false"));

            LlenarDataGV(filtros);
        }

        private void BtnBuscarCrucero_Click(object sender, EventArgs e) // TODO cuando haya SQL video 42
        {
            try
            {
                List<Filtro> filtros = new List<Filtro>();
                filtros.Add(FiltroFactory.Exacto("bajaPorFueraDeServicio", "false"));
                filtros.Add(FiltroFactory.Exacto("bajaPorVidaUtil", "false"));

                if (string.IsNullOrEmpty(txtBuscarCrucero.Text.Trim()) == false)
                    filtros.Add(FiltroFactory.Libre("ID", txtBuscarCrucero.Text.Trim()));

                LlenarDataGV(filtros);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }


        }

        private void Crucero_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LlenarDataGV(List<Filtro> filtros)
        {
            DataTable data = conexion.ConseguirTabla(Tabla.Crucero, filtros);

            data.Columns.Remove("baja_vida_util");
            data.Columns.RemoveAt(9);
            data.Columns.Remove("baja_fuera_de_servicio");
            data.Columns.RemoveAt(8);
            data.Columns.Remove("fecha_baja_definitiva");
            data.Columns.RemoveAt(7);
            data.Columns.Remove("fecha_reinicio_servicio");
            data.Columns.RemoveAt(6);
            data.Columns.Remove("fecha_fuera_de_servicio");
            data.Columns.RemoveAt(5);
            data.Columns.Remove("fecha_de_alta");
            data.Columns.RemoveAt(4);

            dataGridCruceros.DataSource = data;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            new GenerarViaje().Show();
        }
    }



}
