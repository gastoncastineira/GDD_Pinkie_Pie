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
            tipoPiso.DisplayMember = "";
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

                Dictionary<string, object> crucero = new Dictionary<string, object>();
                crucero.Add("modelo", textBox1.Text);
                crucero.Add("fabricante", comboBox2.Text);
                crucero.Add("identificador", textBox2.Text);
                crucero.Add("baja_fuera_de_servicio", false);
                crucero.Add("baja_vida_util", false);
                crucero.Add("fecha_de_alta", ConfigurationHelper.FechaActual);

                int pkCrucero = tr.Insertar(Tabla.Crucero, crucero);

                Dictionary<string, object> piso = new Dictionary<string, object>();

                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {

                    var row = dataGridView1.Rows[i];

                    piso["Nro_piso"] = row.Cells["nroPiso"].Value;
                    piso["id_crucero"] = pkCrucero;
                    piso["id_tipo"] = row.Cells["tipoPiso"].Value.ToString();

                    var tipo = row.Cells["tipoPiso"].Value.ToString();

                    Filtro filtro = FiltroFactory.Exacto("tipo", tipo);

                    var returnAsqueroso = conexion.ConsultaPlana(Tabla.Tipo, new List<string>() { "ID" }, new List<Filtro> { filtro });

                    piso["id_tipo"] = returnAsqueroso["ID"][0];

                    piso["cant_cabina"] = row.Cells["cantCabinasPiso"].Value;

                    tr.Insertar(Tabla.Piso, piso);


                }

                tr.Commit();

                MessageBox.Show("Crucero dado de alta exitosamente. Felicidades :D", "Crucero creado", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private bool dataGridVacio(DataGridView data)
        {

            bool invalido = false;

            for (int j = 0; j < data.Rows.Count - 1; j++)
            {

                var row = data.Rows[j];

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


        private bool stringVacio(string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
