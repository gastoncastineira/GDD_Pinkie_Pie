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
        public Cruceros()
        {
            InitializeComponent();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
           
            if (dataGridCruceros.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            
        }


        private void Cruceros_Load(object sender, EventArgs e)
        {
            // dataGridRecorridos.DataSource = LlenarDataGV("Recorrido"); // ver 10.10 TODO
        }

        private void BtnBuscarCrucero_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarCrucero.Text.Trim()) == false) // ver si sigue quedando si suben algun validador (supongo que no)
            {
                try
                {
                    // "SELECT * FROM Crucero WHERE Id LIKE ('%" + txtBuscar.Text.Trim() + "%')"
                    // 15.12 TODO
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }
            }
        }

        private void Crucero_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /* public DataSet LlenarDataGV(string tabla) // TODO cuando haya SQL video 42
         * 
         * // Se debe tener en cuenta que al momento de seleccionar un crucero este deberá
            // estar disponible y no estar asignado previamente a otro viaje en la fecha que se está ingresando
    {
        DataSet DS;

        string cmd = string.Format("SELECT * FROM " + tabla);
        //DS = ;//ver

        return DS;


        // SELECT crucero_id, marca
           FROM Crucero c
           WHERE (c.bajaPorFueraDeServicio == false && c.bajaPorVidaUtil == false)
           JOIN Viaje v
                ON v.crucero_id = c.id
           HAVING  
        viaje.get_Id()
           // TODO ver como se hace el get
    }*/
    }


}
