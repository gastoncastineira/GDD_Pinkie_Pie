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
using FrbaCrucero.Acceso;

namespace FrbaCrucero.AbmCrucero
{
    public partial class ListaDeCruceros : FormTemplate
    {
        private Conexion conexion = new Conexion();
        public ListaDeCruceros():base()
        {
            InitializeComponent();
        }

        private void ListaDeCruceros_Load(object sender, EventArgs e)
        {
            this.reLoad();
        }

        public void reLoad()
        {
            conexion.LlenarDataGridView(Tabla.Crucero, ref dataGridViewCruceros, null);
            dataGridViewCabinas.DataSource = null;
            dataGridViewCabinas.Rows.Clear();
            dataGridViewCabinas.Refresh();

            for (int i = 3; i < dataGridViewCruceros.Columns.Count ; i++)
            {
                DataGridViewColumn row = dataGridViewCruceros.Columns[i];
                row.ReadOnly = true;
            }


        }

        private void LabelNombreGrid_Click(object sender, EventArgs e)
        {

        }

        private void ButtonOut_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void buttonCrear_Click_1(object sender, EventArgs e)
        {
            AltaCruceros form = new AltaCruceros();
            form.Show();
            form.Focus();
        }

        private void dataGridViewCruceros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            string PK = dataGridViewCruceros.Rows[e.RowIndex].Cells[3].Value.ToString();

            switch (e.ColumnIndex)
            {
                case 1:
                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    {   //Modificar
                        new ModificarCrucero(PK,
                            dataGridViewCruceros.Rows[e.RowIndex].Cells[4].Value.ToString(),
                            dataGridViewCruceros.Rows[e.RowIndex].Cells[5].Value.ToString(),
                            dataGridViewCruceros.Rows[e.RowIndex].Cells[6].Value.ToString()
                            , this).Show();
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

        private void button1_Click(object sender, EventArgs e)
        {

            this.darDeBajaCrucero("baja_fuera_de_servicio");
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.darDeBajaCrucero("baja_vida_util");

        }

        private void darDeBajaCrucero(string baja){

            for (int j = 0; j < dataGridViewCruceros.Rows.Count - 1; j++)
            {

                var check = dataGridViewCruceros.Rows[j].Cells[0];

                if (check.Selected)
                {

                    var id = int.Parse(dataGridViewCruceros.Rows[j].Cells[3].Value.ToString());
                    Dictionary<string,object> modificacion = new Dictionary<string,object>();
                    modificacion.Add(baja, true);
                    conexion.Modificar(id, Tabla.Crucero, modificacion);

                    conexion.CancelarPasajes(id, ConfigurationHelper.FechaActual);

                }

            }

        }

    }
}
