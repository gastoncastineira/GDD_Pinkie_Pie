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
                Close();
            }
        }

        private void Recorridos_Load(object sender, EventArgs e)
        {
            // dataGridRecorridos.DataSource = LlenarDataGV("Recorrido"); // video 42 ver 10.10
        }

        private void BtlBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text.Trim()) == false) // ver si sigue quedando si suben algun validador (supongo que no)
            {
                try
                {
                    // "SELECT * FROM Recorrido WHERE Id LIKE ('%" + txtBuscar.Text.Trim() + "%')"
                    // 15.12
                }
                catch(Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void Recorridos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

   /* public DataSet LlenarDataGV(string tabla) // TODO cuando haya SQL video 42
    {
        DataSet DS;

        string cmd = string.Format("SELECT * FROM " + tabla);
        //DS = ;//ver

        return DS;
    }*/
}
