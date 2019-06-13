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

namespace FrbaCrucero.AbmCrucero
{
    public partial class AltaCruceros : Form
    {

        private Conexion conexion = new Conexion();

        public AltaCruceros()
        {

            InitializeComponent();
            cargarFabricantes();
            cargarTipoPiso();
            
        }


        private void cargarFabricantes(){
            conexion.LlenarComboFabricantes(ref comboBox2);
        }

        private void cargarTipoPiso()
        {
            conexion.LlenarComboTipoPisos(ref tipoPiso);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.camposVacios())
            {
                MessageBox.Show("Se han encontra campos vacios. Por favor completelos e intentelo nuevamente", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Transaccion tr = conexion.IniciarTransaccion();

                Dictionary<string, object> filas = new Dictionary<string, object>();
                filas.Add("modelo", textBox1.Text);
                filas.Add("fabricante", comboBox2.Text);
                filas.Add("identificador", textBox2.Text);
                filas.Add("baja_fuera_de_servicio", false);
                filas.Add("baja_vida_util", false);
                filas.Add("fecha_de_alta", ConfigurationHelper.FechaActual);

                int pkCrucero = tr.Insertar(Tabla.Crucero, filas);

                foreach (DataGridViewRow row in dataGridView1.Rows){

                    filas.Add("Nro_piso",row.Cells["nroPiso"].Value);
                    filas.Add("id_crucero",pkCrucero);
                    filas.Add("id_tipo", row.Cells["tipoPiso"].Value);
                    filas.Add("cant_cabina", row.Cells["cantCabinasPiso"].Value);

                }

                tr.Commit();

                /*
                Transaccion tr = conexion.IniciarTransaccion();

                Dictionary<string, object> registros = new Dictionary<string, object>();
                registros.Add("codigo",1);
                registros.Add("puerto_origen_id", int.Parse(origenID));
                registros.Add("puerto_destino_id", int.Parse(destinoID.Last()));

                int pkRecorrido = tr.Insertar(Tabla.Recorrido, registros);

                tramosID.ForEach( id => tr.InsertarTablaIntermedia(Tabla.Tramo_X_Recorrido, "ID_Recorrido", "ID_Tramo", pkRecorrido, int.Parse(id)));

                tr.Commit();
                */

            }
             
        }

        private bool camposVacios(){

            if (this.stringVacio(textBox1.Text) || this.stringVacio(textBox2.Text) || this.stringVacio(comboBox2.Text) || this.dataGridVacio(dataGridView1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool dataGridVacio(DataGridView data) {

            if (data.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                
                bool invalido = false;
                foreach (DataGridViewRow row in data.Rows){


                    for (int i = 0; i < row.Cells.Count; i++)
                      {
                        if (row.Cells[i].Value == null || row.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()) || String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()))
                        {
                            invalido = true;
                            break;
                        }
                      } 
                    

                    if (invalido)
                    {
                        break;
                    }

                }

                return invalido;

            }

        }

        private bool stringVacio(string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }

    }
}
